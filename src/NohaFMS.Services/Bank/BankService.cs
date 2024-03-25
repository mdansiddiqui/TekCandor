using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;

namespace NohaFMS.Services.Bank
{
    public class BankService : BaseService, IBankService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.Bank> _bankRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BankService(IRepository<NohaFMS.Core.Domain.Bank> bankRepository, DapperContext dapperContext
                    , IDbContext dbContext)
        {
            this._bankRepository = bankRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;

        }

        #endregion

        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.Bank> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.BankSearch(), new { skip = pageIndex * pageSize, take = pageSize });
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
            var count = countBuilder.AddTemplate(SqlTemplate.BankSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var banks = connection.Query<NohaFMS.Core.Domain.Bank>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.Bank>(banks, totalCount);
            }
        }

        #endregion
    }
}
