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
    public interface IWorkOrderService : IBaseService
    {
        PagedResult<WorkOrder> GetWorkOrders(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        /// <summary>
        /// This method is used in WO workflow to get the created user
        /// There's always only one parameter to these methods: Id
        /// Id = EntityId, in this case it is workOrderId.
        /// </summary>
        /// <param name="id">workOrderId</param>
        /// It always return a list of users, even if there's only one.
        List<User> GetCreatedUser(long id);

        /// <summary>
        /// This method is used in WO workflow to get the assigned technicians
        /// </summary>
        /// <param name="id">workOrderId</param>
        /// <returns>Return a list of technicians</returns>
        List<User> GetAssignedTechnicians(long id);

        void CloseWorkOrder(long entityId);

        /// <summary>
        /// Generate WO tasks if the Asset belongs to an Asset Type
        /// that is configured with a Task Group
        /// </summary>
        void GenerateWorkOrderTasks(WorkOrder workOrder, long? assetId);

        WorkOrder CreateNextWorkOrderForPM(WorkOrder workOrder);
        void MaintenanceActivityFlowlog(long id, string description);
    }
}
