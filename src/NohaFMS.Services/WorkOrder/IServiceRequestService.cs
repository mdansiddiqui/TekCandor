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
    public interface IServiceRequestService : IBaseService
    {
        PagedResult<ServiceRequest> GetServiceRequests(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<User> GetCreatedUser(long id);

        void AutoCloseServiceRequest(long? serviceRequestId);
        List<User> GetRequestor(long id);

        void MaintenanceActivityFlowlog(long id, string description);
    }
}
