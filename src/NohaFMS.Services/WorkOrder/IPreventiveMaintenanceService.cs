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
    public interface IPreventiveMaintenanceService : IBaseService
    {
        PagedResult<PreventiveMaintenance> GetPreventiveMaintenances(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        /// <summary>
        /// Creates a next WO for PM. This method
        /// is called by the PMJob.
        /// </summary>
        WorkOrder CreateNextWorkOrder(PreventiveMaintenance preventiveMaintenance,
            DateTime startDateTime,
            DateTime endDateTime);

        void ClosePM(PreventiveMaintenance pm);

        /// <summary>
        /// Generate PM tasks if the Asset belongs to an Asset Type
        /// that is configured with a Task Group
        /// </summary>
        void GeneratePMTasks(PreventiveMaintenance pm, long? assetId);

        void CopyAttachments(List<PMTask> from, List<WorkOrderTask> to);

        //UserActivitylog
        void MaintenanceActivityFlowlog(long id, string description);

    }
}
