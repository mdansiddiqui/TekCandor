/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PhysicalCountItemMap : NohaFMSEntityTypeConfiguration<PhysicalCountItem>
    {
        public PhysicalCountItemMap()
        {
            this.ToTable("PhysicalCountItem");
            this.Property(e => e.CurrentQuantity).HasPrecision(19, 4);
            this.Property(e => e.Count).HasPrecision(19, 4);
            this.HasOptional(e => e.PhysicalCount)
                .WithMany(e => e.PhysicalCountItems)
                .HasForeignKey(e => e.PhysicalCountId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
            this.HasOptional(e => e.StoreLocator)
                .WithMany()
                .HasForeignKey(e => e.StoreLocatorId);
        }
    }
}
