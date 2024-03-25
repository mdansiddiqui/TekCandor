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
    public interface ISecurityGroupService : IBaseService
    {
        PagedResult<SecurityGroup> GetSecurityGroups(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue
        void SecurityActivityFlowlog(long id, string description);
        void SearchFilterLog(string id,string fGroup);

        void Klog(long id, string description);
        void groupBeforeEditBtnLog(long id);
        void groupAfterEditBtnLog(long id, bool IsCreate);
    }
}
