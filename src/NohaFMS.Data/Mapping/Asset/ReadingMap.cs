/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReadingMap : NohaFMSEntityTypeConfiguration<Reading>
    {
        public ReadingMap()
            : base()
        {
            this.ToTable("Reading");
            this.HasOptional(e => e.PointMeterLineItem)
                .WithMany(e => e.Readings)
                .HasForeignKey(e => e.PointMeterLineItemId);
            this.HasOptional(e => e.WorkOrder)
                .WithMany()
                .HasForeignKey(e => e.WorkOrderId);
            this.Property(e => e.ReadingValue).HasPrecision(19, 4);
        }
    }
}
