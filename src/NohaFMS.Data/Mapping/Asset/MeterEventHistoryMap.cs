/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MeterEventHistoryMap : NohaFMSEntityTypeConfiguration<MeterEventHistory>
    {
        public MeterEventHistoryMap()
        {
            this.ToTable("MeterEventHistory");
            this.HasOptional(e => e.MeterEvent)
                .WithMany(e => e.MeterEventHistories)
                .HasForeignKey(e => e.MeterEventId)
                .WillCascadeOnDelete(true);
            this.Property(e => e.GeneratedReading).HasPrecision(19, 4);
        }
    }
}
