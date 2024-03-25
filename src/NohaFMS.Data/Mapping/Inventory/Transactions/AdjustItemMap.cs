/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AdjustItemMap : NohaFMSEntityTypeConfiguration<AdjustItem>
    {
        public AdjustItemMap()
        {
            this.ToTable("AdjustItem");
            this.Property(e => e.AdjustUnitPrice).HasPrecision(19, 4);
            this.Property(e => e.AdjustQuantity).HasPrecision(19, 4);
            this.Property(e => e.AdjustCost).HasPrecision(19, 4);
            this.HasOptional(e => e.Adjust)
                .WithMany(e => e.AdjustItems)
                .HasForeignKey(e => e.AdjustId);
            this.HasOptional(e => e.StoreLocator)
                .WithMany()
                .HasForeignKey(e => e.StoreLocatorId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
