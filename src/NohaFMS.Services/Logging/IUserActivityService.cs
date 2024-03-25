/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    /// <summary>
    /// User activity service interface
    /// </summary>
    public partial interface IUserActivityService : IBaseService
    {
        void InsertActivityLog(string name, string comment,string description);
        void UpdateActivityLog(ActivityLog activityLog);
        ActivityLog GetActivityLog(string name, string comment);
        List<ActivityLog> GetActivityLogs(string name);

        void UserActivityFlowlog(long id, string description);
    }
}
