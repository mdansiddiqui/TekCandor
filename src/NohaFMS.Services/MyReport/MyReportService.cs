//MyReport Service

using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Dapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;

using System.Data.SqlClient;

namespace NohaFMS.Services
{
    class MyReportService : BaseService, IReportService
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IRepository<ReportColumn> _reportColumnRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;

        public Stream CrystalReportExport(Report report, Dictionary<string, string> dictSearch, List<IEnumerable<dynamic>> data, int exportFormatType, string reportSecondTitle, User currentUser, Site clientInfo)
        {

            var type = (ExportFormatType)exportFormatType;
            ReportDocument rd = new ReportDocument();

            string reportTempFolder = ConfigurationManager.AppSettings["ReportTempFolder"].ToString();
            rd.Load(reportTempFolder + report.TemplateFileName);
            //rd.Load("E:/FacilityManagment/nohafms/Implementation Artifacts/nohafms-web/NohaFMS/NohaFMS.Web/Reports/WordOrder.rpt");
            //rd.SetDataSource(ToDataTable(data));
            for (int count = 0; count < data.Count; count++)
            {
                if (rd.Database.Tables.Count > count)
                    rd.Database.Tables[count].SetDataSource(ToDataTable(data[count]));
            }
            //rd.Database.Tables[0].SetDataSource

            // Report Comments to be filled with Search Parameters
            StringBuilder reportComments = new StringBuilder();
            var key = "";
            foreach (ReportFilter rFilter in report.ReportFilters)
            {
                if (dictSearch.ContainsKey(rFilter.Name + "_input") && !string.IsNullOrEmpty(dictSearch[rFilter.Name + "_input"]))
                {
                    reportComments.Append(rFilter.Filter.Name);
                    reportComments.Append(": ");
                    reportComments.Append(dictSearch[rFilter.Name + "_input"].ToString());
                    reportComments.Append(", ");
                }
                else if (dictSearch.ContainsKey(rFilter.Name) && !string.IsNullOrEmpty(dictSearch[rFilter.Name]))
                {
                    reportComments.Append(rFilter.Filter.Name);
                    reportComments.Append(": ");
                    reportComments.Append(dictSearch[rFilter.Name].ToString());
                    reportComments.Append(", ");
                }
            }
            if (reportComments.ToString().Length > 0)
            {
                reportComments = reportComments.Remove(reportComments.Length - 2, 2);
            }
            //foreach (var d in dictSearch)
            //{
            //    //we just care of these filter fields which is shown on UI 
            //    if (d.Key.Contains("_Operator"))
            //    {
            //        //key = d.Key.Replace("_Operator", "");
            //        //reportComments.Append(key);
            //        //Get the field value into field_input instead of getting Id field.
            //        //Except for this case which has not _input field.(contains: textbox)
            //        if (!d.Value.Contains("contains"))
            //        {
            //            //key = d.Key.Replace("_Operator", "_input");
            //        }
            //        //reportComments.Append(" = ");
            //        //reportComments.Append(String.IsNullOrEmpty(dict[key]) ? "ALL" : dict[key]);
            //        //reportComments.Append("\r\n");
            //    }
            //}
            // Report Title
            rd.SummaryInfo.ReportTitle = report.Name;
            // Report Second Title (Optional)
            if (rd.ParameterFields["ReportSecondTitle"] != null && !string.IsNullOrEmpty(reportSecondTitle))
                rd.SetParameterValue("ReportSecondTitle", reportSecondTitle);
            else
                rd.SetParameterValue("ReportSecondTitle", string.Empty);
            // Client Name
            if (rd.ParameterFields["ClientName"] != null && !string.IsNullOrEmpty(clientInfo.Name))
                rd.SetParameterValue("ClientName", clientInfo.Name);
            else
                rd.SetParameterValue("ClientName", string.Empty);
            // Client Address
            if (rd.ParameterFields["ClientAddress"] != null && clientInfo.Addresses != null && clientInfo.Addresses.Count > 0)
            {
                StringBuilder clientAddress = new StringBuilder();
                Address address = clientInfo.Addresses.ElementAt(0);
                if (!string.IsNullOrEmpty(address.Address1))
                {
                    clientAddress.Append(address.Address1);
                    clientAddress.Append(", ");
                }
                if (!string.IsNullOrEmpty(address.Address2))
                {
                    clientAddress.Append(address.Address2);
                    clientAddress.Append(", ");
                }
                if (!string.IsNullOrEmpty(address.City))
                {
                    clientAddress.Append(address.City);
                    clientAddress.Append(" ");
                }
                if (!string.IsNullOrEmpty(address.ZipPostalCode))
                {
                    clientAddress.Append(address.ZipPostalCode);
                    clientAddress.Append(" ");
                }
                if (!string.IsNullOrEmpty(address.StateProvince))
                {
                    clientAddress.Append(address.StateProvince);
                    clientAddress.Append(", ");
                }
                if (!string.IsNullOrEmpty(address.Country))
                {
                    clientAddress.Append(address.Country);
                }
                rd.SetParameterValue("ClientAddress", clientAddress.ToString());
            }
            else
                rd.SetParameterValue("ClientAddress", string.Empty);
            // Search Filters
            if (rd.ParameterFields["SearchFilters"] != null)
                rd.SetParameterValue("SearchFilters", reportComments.ToString());

            // Printed By
            if (rd.ParameterFields["PrintedBy"] != null)
                rd.SetParameterValue("PrintedBy", currentUser.Name);

            //rd.SummaryInfo.ReportComments = reportComments.ToString();
            //rd.SetParameterValue("Date From","12/12/12");
            try
            {
                Stream stream = rd.ExportToStream(type);
                stream.Seek(0, SeekOrigin.Begin);
                return stream;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private DataTable ToDataTable(IEnumerable<dynamic> items)
        {
            var data = items.ToArray();
            if (data.Count() == 0) return null;

            var dt = new DataTable();
            foreach (var key in ((IDictionary<string, object>)data[0]).Keys)
            {
                dt.Columns.Add(key);
            }
            foreach (var d in data)
            {
                dt.Rows.Add(((IDictionary<string, object>)d).Values.ToArray());
            }
            return dt;
        }

        public virtual MemoryStream ExportToCsv(long reportId, IEnumerable<dynamic> data)
        {
            var output = new MemoryStream();
            var writer = new StreamWriter(output, Encoding.UTF8);

            var columns = _reportColumnRepository.GetAll().Where(r => r.ReportId == reportId).ToList();
            for (int index = 0; index < columns.Count; index++)
            {
                if (index == columns.Count - 1)
                    writer.Write(columns[index].ColumnName);
                else
                    writer.Write(columns[index].ColumnName + ",");
            }

            writer.WriteLine();

            foreach (var item in data)
            {
                var itemData = (IDictionary<string, object>)item;

                for (int index = 0; index < columns.Count; index++)
                {
                    var value = itemData[columns[index].ColumnName] == null ? string.Empty : itemData[columns[index].ColumnName].ToString();
                    writer.Write(value);
                    if (index != columns.Count - 1)
                        writer.Write(",");
                }

                writer.WriteLine();
            }

            writer.Flush();
            output.Position = 0;

            return output;
        }

        public virtual MemoryStream ExportToExcel(long reportId, IEnumerable<dynamic> data)
        {
            //Create new Excel workbook
            var workbook = new HSSFWorkbook();

            //Create new Excel sheet
            var sheet = workbook.CreateSheet();

            //Create a header row
            var headerRow = sheet.CreateRow(0);

            //Set the column names in the header row
            var columns = _reportColumnRepository.GetAll().Where(r => r.ReportId == reportId).ToList();
            for (int index = 0; index < columns.Count; index++)
            {
                headerRow.CreateCell(index).SetCellValue(columns[index].ColumnName);
            }

            //(Optional) freeze the header row so it is not scrolled
            sheet.CreateFreezePane(0, 1, 0, 1);

            int rowNumber = 1;

            foreach (var item in data)
            {
                var itemData = (IDictionary<string, object>)item;

                //Create a new row
                var row = sheet.CreateRow(rowNumber++);

                //Set values for the cells
                for (int index = 0; index < columns.Count; index++)
                {
                    var value = itemData[columns[index].ColumnName] == null ? string.Empty : itemData[columns[index].ColumnName].ToString();
                    row.CreateCell(index).SetCellValue(value);
                }
            }

            //Write the workbook to a memory stream
            MemoryStream output = new MemoryStream();
            workbook.Write(output);

            return output;
        }

        public virtual MemoryStream ExportToPdf(long reportId, IEnumerable<dynamic> data)
        {
            // step 1: creation of a document-object
            var document = new Document(PageSize.A4, 10, 10, 10, 10);

            //step 2: we create a memory stream that listens to the document
            var output = new MemoryStream();
            PdfWriter.GetInstance(document, output);

            //step 3: we open the document
            document.Open();

            //step 4: we add content to the document
            var columns = _reportColumnRepository.GetAll().Where(r => r.ReportId == reportId).ToList();
            var numOfColumns = columns.Count;
            var dataTable = new PdfPTable(numOfColumns);

            dataTable.DefaultCell.Padding = 3;

            dataTable.DefaultCell.BorderWidth = 2;
            dataTable.DefaultCell.HorizontalAlignment = Element.ALIGN_CENTER;

            // Adding headers
            for (int index = 0; index < columns.Count; index++)
            {
                dataTable.AddCell(columns[index].ColumnName);
            }

            dataTable.HeaderRows = 1;
            dataTable.DefaultCell.BorderWidth = 1;

            // Add values
            foreach (var item in data)
            {
                var itemData = (IDictionary<string, object>)item;

                for (int index = 0; index < columns.Count; index++)
                {
                    var value = itemData[columns[index].ColumnName] == null ? string.Empty : itemData[columns[index].ColumnName].ToString();
                    dataTable.AddCell(value);
                }
            }

            // Add table to the document
            document.Add(dataTable);

            //This is important don't forget to close the document
            document.Close();

            return output;
        }

        public virtual IEnumerable<dynamic> GetReportData(Report report,
            string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(report.Query, new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy(report.SortExpression);
            }

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var result = connection.Query(search.RawSql, search.Parameters);
                return result;
            }
        }

        public virtual List<IEnumerable<dynamic>> GetReportDataMultiple(Report report,
            string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(report.Query, new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy(report.SortExpression);
            }

            using (var connection = _dapperContext.GetOpenConnection())
            {
                Dapper.SqlMapper.GridReader result = connection.QueryMultiple(search.RawSql, search.Parameters);
                List<IEnumerable<dynamic>> dataTables = new List<IEnumerable<dynamic>>();
                do
                {
                    IEnumerable<dynamic> dataTable = result.Read<dynamic>();
                    dataTables.Add(dataTable);
                } while (!result.IsConsumed);

                return dataTables;
            }
        }

        public PagedResult<Report> GetReports(string expression, dynamic parameters, int pageIndex = 0, int pageSize = int.MaxValue, IEnumerable<Sort> sort = null)
        {
            throw new NotImplementedException();
        }

        public List<Report> GetReportsByUser(User user)
        {
            throw new NotImplementedException();
        }

        public void ReportActivityFlowlog(long id, string description)
        {
            DateTime dto = System.DateTime.Now;
            //string constr = ConfigurationManager.ConnectionStrings();


            var user = _workContext.CurrentUser;
            string connection = _dapperContext.ConnectionString;


            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                // string desc = "City Created where Id is:" + id.ToString();
                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + description.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";





                //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

                //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


                SqlCommand command = new SqlCommand(query, connect);



                connect.Open();

                //string des = (string)onlyonedesc.ExecuteScalar();
                //h = des;
                //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
                //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

                //SqlCommand command1 = new SqlCommand(query1, connect);

                //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
                //string CustomerName = (string)CmdName.ExecuteScalar();

                command.ExecuteNonQuery();

                connect.Close();

            }

        }

    }
}
