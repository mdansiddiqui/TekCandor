/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Data;
using Common.Logging;
using Quartz;
using System;
using System.Linq;

namespace NohaFMS.Services
{
    [DisallowConcurrentExecution]
    public class ClearUrlAccessedLogJob : IJob
    {
        private readonly IRepository<ActivityLog> _activityLogRepository;
        private readonly IDbContext _dbContext;
        private static readonly ILog s_log = LogManager.GetLogger<HeartbeatJob>();

        public ClearUrlAccessedLogJob(IRepository<ActivityLog> activityLogRepository,
            IDbContext dbContext)
        {
            this._activityLogRepository = activityLogRepository;
            this._dbContext = dbContext;
        }

        public void Execute(IJobExecutionContext context)
        {
            var date = DateTime.UtcNow.AddDays(-1);
            var activityLogs = _activityLogRepository.GetAll()
                .Where(a => a.ActivityLogType.Name == "UrlAccessed" && a.ModifiedDateTime < date)
                .ToList();
            foreach (var log in activityLogs)
                _activityLogRepository.Delete(log);

            this._dbContext.SaveChanges();
        }
    }
}
