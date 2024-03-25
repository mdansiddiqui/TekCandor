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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.SqlClient;

namespace NohaFMS.Services
{
    public class TechnicianService : BaseService, ITechnicianService
    {
        #region Fields

        private readonly IRepository<Technician> _technicianRepository;
        private readonly IRepository<Team> _teamRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public TechnicianService(IRepository<Technician> technicianRepository,
            IRepository<Team> teamRepository,
            DapperContext dapperContext,
            IDbContext dbContext,
            IWorkContext workContext
            )
        {
            this._technicianRepository = technicianRepository;
            this._teamRepository = teamRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<Technician> GetTechnicians(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.TechnicianSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Technician.Name");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.TechnicianSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var technicians = connection.Query<Technician, User, Calendar, Shift, Craft, Technician> (search.RawSql,
                   (technician, user, calendar, shift, craft) => { technician.User = user; technician.Calendar = calendar; technician.Shift = shift; technician.Craft = craft; return technician; }, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<Technician>(technicians, totalCount);
            }
        }

        public virtual List<Technician> GetTechnicians(long? teamId, int? technicianMatching, DateTime? dateTime, string param)
        {
            var technicians = _teamRepository.GetById(teamId).Technicians
                .Where(t => t.User.Name.Contains(param))
                .OrderBy(t => t.User.Name)
                .ToList();
            if(technicianMatching == (int?)TechnicianMatching.Shift)
            {
                if (dateTime.HasValue)
                {
                    technicians = technicians.Where(t => t.Shift.ShiftPatterns.Any(p => p.StartTime.Value.Hour <= dateTime.Value.Hour
                                                        && p.EndTime.Value.Hour >= dateTime.Value.Hour))
                                                .ToList();
                }
                else
                {
                    return new List<Technician>();
                }
            }

            return technicians;
        }


        public void ResourceActivityFlowlog(long id, string description)
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
