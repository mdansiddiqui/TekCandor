/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class PMLabor : BaseEntity
    {
        public long? PreventiveMaintenanceId { get; set; }
        public virtual PreventiveMaintenance PreventiveMaintenance { get; set; }

        public long? TeamId { get; set; }
        public virtual Team Team { get; set; }

        public long? TechnicianId { get; set; }
        public virtual Technician Technician { get; set; }

        public long? CraftId { get; set; }
        public virtual Craft Craft { get; set; }

        public decimal? PlanHours { get; set; }
        public decimal? StandardRate { get; set; }
        public decimal? OTRate { get; set; }
        public decimal? PlanTotal { get; set; }
    }
}
