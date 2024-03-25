/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PMMiscCostMap : NohaFMSEntityTypeConfiguration<PMMiscCost>
    {
        public PMMiscCostMap()
            : base()
        {
            this.ToTable("PMMiscCost");
            this.HasOptional(e => e.PreventiveMaintenance)
                .WithMany(e => e.PMMiscCosts)
                .HasForeignKey(e => e.PreventiveMaintenanceId);
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.PlanUnitPrice).HasPrecision(19, 4);
            this.Property(e => e.PlanQuantity).HasPrecision(19, 4);
            this.Property(e => e.PlanTotal).HasPrecision(19, 4);
        }
    }
}
