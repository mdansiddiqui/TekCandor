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
    public interface ITransferService : IBaseService
    {
        PagedResult<Transfer> GetTransfers(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        void UpdateTransferCost(TransferItem transferItem);

        List<StoreLocatorItemAdjustment> CheckSufficientQuantity(Transfer transfer);

        void Approve(Transfer transfer);
    }
}
