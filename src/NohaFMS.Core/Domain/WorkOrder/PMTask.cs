/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class PMTask : BaseEntity
    {
        public long? PreventiveMaintenanceId { get; set; }
        public virtual PreventiveMaintenance PreventiveMaintenance { get; set; }

        public int? Sequence { get; set; }
        public string Description { get; set; }

        public long? AssignedUserId { get; set; }
        public virtual Technician AssignedUser { get; set; }
    }
}
