/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface ICalendarService : IBaseService
    {
        PagedResult<Calendar> GetCalendars(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        /// <summary>
        /// Determine the next work order's date of PM.
        /// </summary>
        bool DetermineNextDate(PreventiveMaintenance pm, ref DateTime start, ref DateTime end);

        void ResourceActivityFlowlog(long id, string description);

    }
}
