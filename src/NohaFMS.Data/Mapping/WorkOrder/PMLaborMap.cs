/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PMLaborMap : NohaFMSEntityTypeConfiguration<PMLabor>
    {
        public PMLaborMap()
            : base()
        {
            this.ToTable("PMLabor");
            this.HasOptional(e => e.PreventiveMaintenance)
                .WithMany(e => e.PMLabors)
                .HasForeignKey(e => e.PreventiveMaintenanceId);
            this.HasOptional(e => e.Team)
                .WithMany()
                .HasForeignKey(e => e.TeamId);
            this.HasOptional(e => e.Technician)
                .WithMany()
                .HasForeignKey(e => e.TechnicianId);
            this.HasOptional(e => e.Craft)
                .WithMany()
                .HasForeignKey(e => e.CraftId);
            this.Property(e => e.PlanHours).HasPrecision(19, 4);
            this.Property(e => e.StandardRate).HasPrecision(19, 4);
            this.Property(e => e.OTRate).HasPrecision(19, 4);
            this.Property(e => e.PlanTotal).HasPrecision(19, 4);
        }
    }
}
