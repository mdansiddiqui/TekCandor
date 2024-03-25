/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ItemMap : NohaFMSEntityTypeConfiguration<Item>
    {
        public ItemMap()
        {
            this.ToTable("Item");
            this.Property(s => s.Description).HasMaxLength(512);
            this.Property(s => s.Barcode).HasMaxLength(64);
            this.Property(e => e.UnitPrice).HasPrecision(19, 4);
            this.HasOptional(e => e.Manufacturer)
                .WithMany()
                .HasForeignKey(e => e.ManufacturerId);
            this.HasOptional(e => e.ItemGroup)
                .WithMany()
                .HasForeignKey(e => e.ItemGroupId);
            this.HasOptional(e => e.UnitOfMeasure)
                .WithMany()
                .HasForeignKey(e => e.UnitOfMeasureId);
            this.HasOptional(e => e.ItemStatus)
                .WithMany()
                .HasForeignKey(e => e.ItemStatusId);
        }
    }
}
