/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreItemMap : NohaFMSEntityTypeConfiguration<StoreItem>
    {
        public StoreItemMap()
        {
            this.ToTable("StoreItem");
            this.Property(e => e.StandardCostingUnitPrice).HasPrecision(19, 4);
            this.Property(e => e.SafetyStock).HasPrecision(19, 4);
            this.Property(e => e.ReorderPoint).HasPrecision(19, 4);
            this.Property(s => s.EconomicOrderQuantity).HasPrecision(19, 4);
            this.HasOptional(e => e.Store)
                .WithMany(e => e.StoreItems)
                .HasForeignKey(e => e.StoreId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
