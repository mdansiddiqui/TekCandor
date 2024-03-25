/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreLocatorItemMap : NohaFMSEntityTypeConfiguration<StoreLocatorItem>
    {
        public StoreLocatorItemMap()
        {
            this.ToTable("StoreLocatorItem");
            this.Property(e => e.UnitPrice).HasPrecision(19, 4);
            this.Property(e => e.Quantity).HasPrecision(19, 4);
            this.Property(e => e.Cost).HasPrecision(19, 4);
            this.Property(s => s.LotNumber).HasMaxLength(64);
            this.HasOptional(e => e.Store)
                .WithMany()
                .HasForeignKey(e => e.StoreId);
            this.HasOptional(e => e.StoreLocator)
                .WithMany(e => e.StoreLocatorItems)
                .HasForeignKey(e => e.StoreLocatorId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
