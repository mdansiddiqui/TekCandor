using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;
using System;
using System.Web;
using System.Data;


namespace NohaFMS.Services.ReturnReason
{
    public class ReturnReasonService : BaseService, IReturnReasonService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.ReturnReason> _returnReasonRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private HttpContextBase _httpContext;

        #endregion
        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public ReturnReasonService(IRepository<NohaFMS.Core.Domain.ReturnReason> returnReasonRepository, DapperContext dapperContext
                    , IDbContext dbContext, IWorkContext workContext, IUserActivityService userActivityService, HttpContextBase httpContext)
        {
            this._returnReasonRepository = returnReasonRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
        }
        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.ReturnReason> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.ReaturnReasonSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Name");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ReturnReasonSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var returnreasons = connection.Query<NohaFMS.Core.Domain.ReturnReason>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.ReturnReason>(returnreasons, totalCount);
            }
        }


        static string ctname, ctcode, cnift, cemail;
        static long hubid;

        public void searchFilterLog(string fReturnReasonName)
        {
            string returnReasonname;


            if (fReturnReasonName == null || fReturnReasonName == "")
            {
                fReturnReasonName = "";
                returnReasonname = $"{fReturnReasonName}";
            }
            else
            {
                returnReasonname = $"ReturnReason Name = {fReturnReasonName}";
            }

            string data = $"Searched for {returnReasonname}";
            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else if (data != "")
            {
                long user = _workContext.CurrentUser.Id;
                DateTime dtnow = DateTime.Now;
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, data);


            }
        }

        NohaFMS.Core.Domain.ReturnReason beforeChange = new NohaFMS.Core.Domain.ReturnReason();
        List<NohaFMS.Core.Domain.ReturnReason> listBeforeEdit = new List<NohaFMS.Core.Domain.ReturnReason>();

        NohaFMS.Core.Domain.ReturnReason afterChange = new NohaFMS.Core.Domain.ReturnReason();
        List<NohaFMS.Core.Domain.ReturnReason> listAfterEdit = new List<NohaFMS.Core.Domain.ReturnReason>();
        public void returnReasonBeforeEditBtnLog(long id)
        {
            DataSet dataSet = new DataSet();

            using (SqlConnection con = new SqlConnection(_dapperContext.ConnectionString))
            {
                using (SqlCommand chcmd = new SqlCommand("Select * from [dbo].[ReturnReason] where Id=" + id, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(chcmd);
                    da.Fill(dataSet);

                    listBeforeEdit = new List<NohaFMS.Core.Domain.ReturnReason>();


                    NohaFMS.Core.Domain.ReturnReason citytemp = new NohaFMS.Core.Domain.ReturnReason();
                    long cId = (long)dataSet.Tables[0].Rows[0]["Id"];

                    string cName = (string)dataSet.Tables[0].Rows[0]["Name"];
                    


                    citytemp.Id = cId;
                    citytemp.Name = cName;
                   


                    listBeforeEdit.Add(citytemp);
                    beforeChange.Name = listBeforeEdit[0].Name;
                    
                }
                con.Close();
            }
         
        }

        public void returnReasonAfterEditBtnLog(long id, bool IsCreate)
        {

            var cityName = ctname;
            
           
            DataSet dataSet2 = new DataSet();

            using (SqlConnection con = new SqlConnection(_dapperContext.ConnectionString))
            {
                using (SqlCommand chcmd = new SqlCommand("Select * from ReturnReason where Id=" + id, con))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter(chcmd);
                    da.Fill(dataSet2);

                    listAfterEdit = new List<NohaFMS.Core.Domain.ReturnReason>();


                    NohaFMS.Core.Domain.ReturnReason cityAfter = new NohaFMS.Core.Domain.ReturnReason();
                    long cId = (long)dataSet2.Tables[0].Rows[0]["Id"];


                    cityAfter.Id = cId;
                    cityAfter.Name = (string)dataSet2.Tables[0].Rows[0]["Name"];
                    //cityAfter.Code = (string)dataSet2.Tables[0].Rows[0]["Code"];
                    //cityAfter.NIFTBranchCode = (string)dataSet2.Tables[0].Rows[0]["NIFTBranchCode"];
                    //cityAfter.HubId = (long)dataSet2.Tables[0].Rows[0]["HubId"];
                    //cityAfter.Email = (string)dataSet2.Tables[0].Rows[0]["Email"];


                    listAfterEdit.Add(cityAfter);
                    afterChange.Name = listAfterEdit[0].Name;
                    //afterChange.Code = listAfterEdit[0].Code;
                    //afterChange.NIFTBranchCode = listAfterEdit[0].NIFTBranchCode;
                    //afterChange.HubId = listAfterEdit[0].HubId;
                    //afterChange.Email = listAfterEdit[0].Email;
                }
                con.Close();
            }
            string cName, cCode, bnift, bhub, bemail;


            if (afterChange.Name != cityName)
            {
                cName = $" Name= {cityName}->{afterChange.Name},";
            }
            else { cName = ""; }
          




            string data = $"{cName}";

            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string operation;
                if (IsCreate == true)
                {

                    operation = $"ReturnReason has been created with Id={id}";

                }
                else
                {
                    operation = $"ReturnReason Modified of Id={id}, Name and Code are: " + afterChange.Name ;
                }

                long user = _workContext.CurrentUser.Id;
                DateTime dtnow = DateTime.Now;
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation}   {data}");


            }

        }

        public void returnReasonAfterEditBtnLog(long id)
        {
            throw new NotImplementedException();
        }

        

        #endregion
    } 
}



#endregion
