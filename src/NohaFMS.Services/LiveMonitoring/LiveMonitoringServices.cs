using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;

namespace NohaFMS.Services
{
    public class LiveMonitoringServices : BaseService, ILiveMonitoringServices
    {

        private readonly IRepository<LiveMonitoring> _liveMonitoringRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        //private readonly IRepository<ChequeDepositInformation> _chequeDepositRepository;
        //private readonly DapperContext _dapperContext;
        //private readonly IDbContext _dbContext;
        public LiveMonitoringServices(IRepository<LiveMonitoring> liveMonitoringRepository,
           DapperContext dapperContext,
           IDbContext dbContext,
           IWorkContext workContext
           )
        {
            this._liveMonitoringRepository = liveMonitoringRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
        }


        public PagedResult<LiveMonitoring> GetLiveMonitoring(string expression, dynamic parameters, int pageIndex = 0, int pageSize = int.MaxValue, IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.LiveMonitoringSearch(),
                new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("LiveMonitoring.LiveName");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.LiveMonitoringSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var liveMonitoring = connection.Query<LiveMonitoring>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<LiveMonitoring>(liveMonitoring, totalCount);
            }
            //throw new NotImplementedException();
        }

        List<LiveMonitoring> ILiveMonitoringServices.GetAllAssetsByParentId(string name, string branchname,
                                                                            string branchcode)
        {
            string lname, lbranchname, lbranchcode;
            lname = name;
            lbranchname = branchname;
            lbranchcode = branchcode;

            if (string.IsNullOrEmpty(lname) && string.IsNullOrEmpty(lbranchname))
            {
                //date_to = DateTime.Today;
                //date_from = DateTime.Today;
                var result = _liveMonitoringRepository.GetAll().Where(c => c.LiveName == name).ToList();

                return result;
            }
            else if (!string.IsNullOrEmpty(lname) && !string.IsNullOrEmpty(lbranchname))
            {
                //DateTime DT = DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                //DateTime Df = DateTime.ParseExact(df, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var assets = _liveMonitoringRepository.GetAll().Where(c => c.LiveName == name).ToList();

                return assets;
            }
            else if (string.IsNullOrEmpty(lname) && !string.IsNullOrEmpty(lbranchname))
            {

                //DateTime Df = DateTime.ParseExact(df, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                var assets = _liveMonitoringRepository.GetAll().Where(c => c.LiveName == name).ToList();

                return assets;
            }
            //var assets = _chequeDepositRepository.GetAll().Where(c => c.Callback == callback && c.Date>=DT && c.Date>= Df).OrderBy(c => c.Date).ToList();

            return new List<LiveMonitoring>();

            // //   throw new NotImplementedException();

        }

        public void MonitoringActivityFlowlog(long id, string description)
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
