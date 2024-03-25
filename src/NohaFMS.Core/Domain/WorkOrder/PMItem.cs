/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class PMItem : BaseEntity
    {
        public long? PreventiveMaintenanceId { get; set; }
        public virtual PreventiveMaintenance PreventiveMaintenance { get; set; }

        public long? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public long? StoreLocatorId { get; set; }
        public virtual StoreLocator StoreLocator { get; set; }

        public decimal? UnitPrice { get; set; }
        public decimal? PlanQuantity { get; set; }
        public decimal? PlanTotal { get; set; }

        public decimal? PlanToolHours { get; set; }
        public decimal? ToolRate { get; set; }
    }
}
