/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PMServiceItemMap : NohaFMSEntityTypeConfiguration<PMServiceItem>
    {
        public PMServiceItemMap()
            : base()
        {
            this.ToTable("PMServiceItem");
            this.HasOptional(e => e.PreventiveMaintenance)
                .WithMany(e => e.PMServiceItems)
                .HasForeignKey(e => e.PreventiveMaintenanceId);
            this.HasOptional(e => e.ServiceItem)
                .WithMany()
                .HasForeignKey(e => e.ServiceItemId);
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.PlanUnitPrice).HasPrecision(19, 4);
            this.Property(e => e.PlanQuantity).HasPrecision(19, 4);
            this.Property(e => e.PlanTotal).HasPrecision(19, 4);
        }
    }
}
