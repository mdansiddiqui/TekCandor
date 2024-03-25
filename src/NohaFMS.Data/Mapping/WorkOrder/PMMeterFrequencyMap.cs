/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PMMeterFrequencyMap : NohaFMSEntityTypeConfiguration<PMMeterFrequency>
    {
        public PMMeterFrequencyMap()
            : base()
        {
            this.ToTable("PMMeterFrequency");
            this.HasOptional(e => e.PreventiveMaintenance)
                .WithMany(e => e.PMMeterFrequencies)
                .HasForeignKey(e => e.PreventiveMaintenanceId);
            this.HasOptional(e => e.Meter)
                .WithMany()
                .HasForeignKey(e => e.MeterId);
            this.Property(e => e.Frequency).HasPrecision(19, 4);
            this.Property(e => e.EndReading).HasPrecision(19, 4);
            this.Property(e => e.GeneratedReading).HasPrecision(19, 4);
        }
    }
}
