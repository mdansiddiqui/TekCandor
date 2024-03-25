/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PointMeterLineItemMap : NohaFMSEntityTypeConfiguration<PointMeterLineItem>
    {
        public PointMeterLineItemMap()
        {
            this.ToTable("PointMeterLineItem");
            this.HasOptional(e => e.Meter)
                .WithMany()
                .HasForeignKey(e => e.MeterId);
            this.HasOptional(e => e.Point)
                .WithMany(e => e.PointMeterLineItems)
                .HasForeignKey(e => e.PointId)
                .WillCascadeOnDelete(true);
            this.Property(e => e.LastReadingValue).HasPrecision(19, 4);
            this.Property(e => e.LastReadingUser).HasMaxLength(64);
        }
    }
}
