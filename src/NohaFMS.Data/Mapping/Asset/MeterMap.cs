/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MeterMap : NohaFMSEntityTypeConfiguration<Meter>
    {
        public MeterMap()
        {
            this.ToTable("Meter");
            this.Property(s => s.Description).HasMaxLength(512);
            this.HasOptional(e => e.MeterType)
                .WithMany()
                .HasForeignKey(e => e.MeterTypeId);
            this.HasOptional(e => e.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(e => e.UnitOfMeasureId);
        }
    }
}
