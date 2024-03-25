/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using System.Collections.Generic;

namespace NohaFMS.Core
{
    public class PagedResult<T>
    {
        public IEnumerable<Report> reports;

        public IEnumerable<T> Result { get; set; }
        public int TotalCount { get; set; }

        public PagedResult(IEnumerable<T> result, int totalCount)
        {
            this.Result = result;
            this.TotalCount = totalCount;
        }

        public PagedResult(IEnumerable<Report> reports, int totalCount)
        {
            this.reports = reports;
            TotalCount = totalCount;
        }
    }
}
