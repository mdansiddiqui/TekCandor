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
    public class TaskGroupService : BaseService, ITaskGroupService
    {
        #region Fields

        private readonly IRepository<TaskGroup> _taskGroupRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public TaskGroupService(IRepository<TaskGroup> taskGroupRepository,
            DapperContext dapperContext,
            IDbContext dbContext, IWorkContext workContext)
        {
            this._taskGroupRepository = taskGroupRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<TaskGroup> GetTaskGroups(string expression,
            dynamic parataskGroups,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.TaskGroupSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parataskGroups);
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
            var count = countBuilder.AddTemplate(SqlTemplate.TaskGroupSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parataskGroups);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var taskGroups = connection.Query<TaskGroup>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<TaskGroup>(taskGroups, totalCount);
            }
        }
        public void MaintenanceActivityFlowlog(long id, string description)
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
