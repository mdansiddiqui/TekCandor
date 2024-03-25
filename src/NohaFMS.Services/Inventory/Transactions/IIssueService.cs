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
    public interface IIssueService : IBaseService
    {
        PagedResult<Issue> GetIssues(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        PagedResult<IssueItem> GetApprovedIssueItems(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        void UpdateIssueCost(IssueItem issueItem);

        List<StoreLocatorItemAdjustment> CheckSufficientQuantity(Issue issue);

        void Approve(Issue issue);
    }
}
