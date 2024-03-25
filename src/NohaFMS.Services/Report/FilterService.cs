/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;

namespace NohaFMS.Services
{
    public class FilterService : BaseService, IFilterService
    {
        #region Fields

        private readonly IRepository<Filter> _filterRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public FilterService(IRepository<Filter> filterRepository,
            DapperContext dapperContext,
            IDbContext dbContext, IWorkContext workContext)
        {
            this._filterRepository = filterRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<Filter> GetFilters(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Core.Kendoui.Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.FilterSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Name ASC");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.FilterSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var filters = connection.Query<Filter>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<Filter>(filters, totalCount);
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



        #endregion
    }
}
