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
    public class ValueItemService : BaseService, IValueItemService
    {
        private readonly IRepository<ValueItem> _valueItemRepository;
        private readonly DapperContext _dapperContext;

        public ValueItemService(DapperContext dapperContext,
            IRepository<ValueItem> valueItemRepository)
        {
            this._dapperContext = dapperContext;
            this._valueItemRepository = valueItemRepository;
        }

        public virtual PagedResult<ValueItem> GetValueItems(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null)
        {
            var builder = new SqlBuilder();
            var search = builder.AddTemplate(SqlTemplate.ValueItemSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                builder.Where(expression, parameters);

            if (sort != null)
            {
                foreach (var s in sort)
                {
                    builder.OrderBy(s.ToExpression());
                }
                   
            }
            else
            {
                builder.OrderBy("ValueItemCategory.Name");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ValueItemSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var valueItems = connection.Query<ValueItem, ValueItemCategory, ValueItem>(search.RawSql, (valueItem, valueItemCategory) => { valueItem.ValueItemCategory = valueItemCategory; return valueItem; }, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ValueItem>(valueItems, totalCount);
            }
        }

        public virtual List<ValueItem> GetValueItemsByCategory(string category, string param)
        {
            var valueItems = _valueItemRepository.GetAll()
                .Where(v => v.ValueItemCategory.Name == category && v.Name.Contains(param))
                .OrderBy(v => v.Name)
                .ToList();
            return valueItems;
        }
    }
}
