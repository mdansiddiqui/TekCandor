/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;
using System.IO;

namespace NohaFMS.Services
{
    public interface IReportService : IBaseService
    {
        PagedResult<Report> GetReports(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue
        PagedResult<MyReport> GetMyReports(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null);
        List<Report> GetReportsByUser(User user);

        IEnumerable<dynamic> GetReportData(Report report,
            string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null);

        List<IEnumerable<dynamic>> GetReportDataMultiple(Report report,
            string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null);

        MemoryStream ExportToCsv(long reportId, IEnumerable<dynamic> data);

        MemoryStream ExportToExcel(long reportId, IEnumerable<dynamic> data);

        MemoryStream ExportToPdf(long reportId, IEnumerable<dynamic> data);

        Stream CrystalReportExport(Report report, Dictionary<string, string> dictSearch, List<IEnumerable<dynamic>> data, int exportFormatType, string reportSecondTitle, User currentUser, Site clientInfo);
    }
}
