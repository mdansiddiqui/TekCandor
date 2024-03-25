/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
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
using System.Web;

namespace NohaFMS.Services
{
    public class VisualService : BaseService, IVisualService
    {
        #region Fields

        private readonly IRepository<Visual> _visualRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private readonly HttpContextBase _httpContext;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public VisualService(IRepository<Visual> visualRepository,
            DapperContext dapperContext,
            IDbContext dbContext,
            IWorkContext workContext,IUserActivityService userActivityService, HttpContextBase httpContext)
        {
            this._visualRepository = visualRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<Visual> GetVisuals(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.VisualSearch(), new { skip = pageIndex * pageSize, take = pageSize });
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
            var count = countBuilder.AddTemplate(SqlTemplate.VisualSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var visuals = connection.Query<Visual>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<Visual>(visuals, totalCount);
            }
        }

        public virtual List<Visual> GetVisualsByUser(User user)
        {
            var result = new List<Visual>();
            var securityGroupIds = user.SecurityGroups.Select(g => g.Id).ToList();
            result = _visualRepository.GetAll()
                .Where(r => r.SecurityGroups.Any(g => securityGroupIds.Contains(g.Id)))
                .OrderBy(r => r.Name)
                .ToList();
            return result;
        }

        public virtual IEnumerable<dynamic> GetVisualData(Visual visual,
            string expression,
            dynamic parameters,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(visual.Query);
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy(visual.SortExpression);
            }

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var result = connection.Query(search.RawSql, search.Parameters);
                return result;
            }
        }

        public void VisualActivityFlowlog(long id, string description)
        {
            DateTime dto = System.DateTime.Now;
            //string constr = ConfigurationManager.ConnectionStrings();


            var user = _workContext.CurrentUser.Id;
            string connection = _dapperContext.ConnectionString;


            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                // string desc = "City Created where Id is:" + id.ToString();
                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + description.ToString() + "','" + user + "','" + dto.ToString() + "')";





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

        public void ReportActivityFlowlog(long id, string description)
        {
            DateTime dto = System.DateTime.Now;
            //string constr = ConfigurationManager.ConnectionStrings();


            var user = _workContext.CurrentUser.Id;
            string connection = _dapperContext.ConnectionString;


            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                // string desc = "City Created where Id is:" + id.ToString();
                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + description.ToString() + "','" + user + "','" + dto.ToString() + "')";





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

        public void searchFilterLog(string fVisual)
        {
            string cityname;
            if (fVisual == null || fVisual == "")
            {
                fVisual = "";
                cityname = $"{fVisual}";
            }
            else
            {
                cityname = $"Visual Name = {fVisual}";
            }

            string data = $"{cityname}";
            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string desc = $"Searched for {data}";
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);
            }
        }



        #endregion
    }
}
