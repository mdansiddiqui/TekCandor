/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Linq;
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Data;
using System.Collections.Generic;
using System;
using System.Data.SqlClient;

namespace NohaFMS.Services
{
    /// <summary>
    /// User activity service
    /// </summary>
    public class UserActivityService : BaseService, IUserActivityService
    {
        #region Fields

        private const int _deleteNumberOfEntries = 1000;

        private readonly IRepository<ActivityLog> _activityLogRepository;
        private readonly IRepository<ActivityLogType> _activityLogTypeRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;
        private readonly DapperContext _dapperContext;

        #endregion

        #region Ctor

        public UserActivityService(
            IRepository<ActivityLog> activityLogRepository,
            IRepository<ActivityLogType> activityLogTypeRepository,
            IRepository<User> userRepository,
            IWorkContext workContext,
            IDbContext dbContext,
            DapperContext dapperContext
            )
        {
            this._activityLogRepository = activityLogRepository;
            this._activityLogTypeRepository = activityLogTypeRepository;
            this._userRepository = userRepository;
            this._workContext = workContext;
            this._dbContext = dbContext;
            this._dapperContext = dapperContext;

        }

        #endregion

        #region Methods

        public virtual void InsertActivityLog(string name, string comment,string description)
        {
            var user = _workContext.CurrentUser;
            if (user == null)
                return;
            var activityLogType = _activityLogTypeRepository.GetAll().SingleOrDefault(a => a.Name == name);
            if (activityLogType == null)
                return;
            var activityLog = new ActivityLog
            {
                ActivityLogTypeId = activityLogType.Id,
                UserId = user.Id,
                Comment = comment,
                Description = description
            };
            if (activityLog.Description != "")
            {
                //Entry in Log file
                ComLogging.logger($"{user.LoginName} {activityLog.Comment} {activityLog.Description}");
                // Entry in DB
                _activityLogRepository.InsertAndCommit(activityLog);
            }
        }

        public virtual void UpdateActivityLog(ActivityLog activityLog)
        {
            activityLog.ModifiedDateTime = DateTime.UtcNow;
            _activityLogRepository.UpdateAndCommit(activityLog);
          
        }

        public virtual ActivityLog GetActivityLog(string name, string comment)
        {
            var user = _workContext.CurrentUser;
            if (user == null)
                return null;
            var activityLog = _activityLogRepository.GetAll()
                .Where(a => a.UserId == user.Id && a.ActivityLogType.Name == name && a.Comment == comment)
                .FirstOrDefault();

            return activityLog;
        }

        public virtual List<ActivityLog> GetActivityLogs(string name)
        {
            var user = _workContext.CurrentUser;
            if (user == null)
                return null;
            return _activityLogRepository.GetAll()
                .Where(a => a.UserId == user.Id && a.ActivityLogType.Name == name)
                .OrderByDescending(a => a.ModifiedDateTime)
                .ToList();
        }


        public void UserActivityFlowlog(long id, string description)
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
