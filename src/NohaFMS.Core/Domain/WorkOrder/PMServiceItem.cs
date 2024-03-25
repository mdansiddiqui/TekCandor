/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class PMServiceItem : BaseEntity
    {
        public long? PreventiveMaintenanceId { get; set; }
        public virtual PreventiveMaintenance PreventiveMaintenance { get; set; }

        public long? ServiceItemId { get; set; }
        public virtual ServiceItem ServiceItem { get; set; }

        public string Description { get; set; }
        public decimal? PlanUnitPrice { get; set; }
        public decimal? PlanQuantity { get; set; }
        public decimal? PlanTotal { get; set; }
    }
}
