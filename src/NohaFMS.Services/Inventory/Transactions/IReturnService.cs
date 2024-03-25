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
    public interface IReturnService : IBaseService
    {
        PagedResult<Return> GetReturns(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<StoreLocatorItemAdjustment> CheckSufficientQuantity(Return returnEntity);

        void Approve(Return returnEntity); //named parameter is returnEntity because return is a keyword
    }
}
