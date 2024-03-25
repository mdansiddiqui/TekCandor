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
    public interface IAdjustService : IBaseService
    {
        PagedResult<Adjust> GetAdjusts(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null); //Int32.MaxValue

        void UpdateAdjustCost(AdjustItem adjustItem);

        List<StoreLocatorItemAdjustment> CheckSufficientQuantity(Adjust adjust);

        void Approve(Adjust adjust);
    }
}
