/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class WorkOrderTask : BaseEntity, ISyncEntity
    {
        public WorkOrderTask()
        {
            SyncId = Guid.NewGuid().ToString();
        }
        public string SyncId { get; set; }

        public long? WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public int? Sequence { get; set; }
        public string Description { get; set; }

        public long? AssignedUserId { get; set; }
        public virtual User AssignedUser { get; set; }

        public bool Completed { get; set; }

        public long? CompletedUserId { get; set; }
        public virtual User CompletedUser { get; set; }

        public DateTime? CompletedDate { get; set; }

        public decimal? HoursSpent { get; set; }
        public int? Result { get; set; }
        public string CompletionNotes { get; set; }
    }

    public enum TaskResult
    {
        None = 0,
        Passed,
        Failed
    }
}
