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

namespace NohaFMS.Services
{
    public class AuditEntityConfigurationService : BaseService, IAuditEntityConfigurationService
    {
        #region Fields

        private readonly IRepository<AuditEntityConfiguration> _auditEntityConfigurationRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public AuditEntityConfigurationService(IRepository<AuditEntityConfiguration> auditEntityConfigurationRepository,
            DapperContext dapperContext,
            IDbContext dbContext)
        {
            this._auditEntityConfigurationRepository = auditEntityConfigurationRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<AuditEntityConfiguration> GetAuditEntityConfigurations(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.AuditEntityConfigurationSearch(), new { skip = pageIndex * pageSize, take = pageSize });
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
            var count = countBuilder.AddTemplate(SqlTemplate.AuditEntityConfigurationSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var auditEntityConfigurations = connection.Query<AuditEntityConfiguration>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<AuditEntityConfiguration>(auditEntityConfigurations, totalCount);
            }
        }

        #endregion
    }
}
