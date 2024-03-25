/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IMeterService : IBaseService
    {
        PagedResult<Meter> GetMeters(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        /// <summary>
        /// Check and create new meter event histories if the reading value does not fall in the threshold limits.
        /// </summary>
        void CreateMeterEventHistory(PointMeterLineItem item, Reading newReading);
        
        void AssetActivityFlowlog(long id, string description);

    }
}
