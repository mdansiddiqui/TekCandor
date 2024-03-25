/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IFilterService : IBaseService
    {
        PagedResult<Filter> GetFilters(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Core.Kendoui.Sort> sort = null); //Int32.MaxValue
        void ReportActivityFlowlog(long id, string description);
    }
}
