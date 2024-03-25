using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IAutoNumberService : IBaseService
    {
        PagedResult<AutoNumber> GetAutoNumbers(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        /// <summary>
        /// Generates the next auto number based on the date, and the specified
        /// entity.
        /// </summary>
        /// <param name="date"></param>
        /// <param name="entity"></param>
        string GenerateNextAutoNumber<T>(DateTime date, T entity) where T : BaseEntity;
    }
}
