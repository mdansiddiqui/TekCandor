﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreLocatorItemLogMap : NohaFMSEntityTypeConfiguration<StoreLocatorItemLog>
    {
        public StoreLocatorItemLogMap()
        {
            this.ToTable("StoreLocatorItemLog");
            this.Property(e => e.UnitPrice).HasPrecision(19, 4);
            this.Property(e => e.QuantityChanged).HasPrecision(19, 4);
            this.Property(e => e.CostChanged).HasPrecision(19, 4);
            this.Property(s => s.TransactionType).HasMaxLength(64);
            this.Property(s => s.TransactionNumber).HasMaxLength(64);
            this.HasOptional(e => e.StoreLocatorItem)
                .WithMany(e => e.StoreLocatorItemLogs)
                .HasForeignKey(e => e.StoreLocatorItemId);
            this.HasOptional(e => e.Store)
                .WithMany()
                .HasForeignKey(e => e.StoreId);
            this.HasOptional(e => e.StoreLocator)
                .WithMany()
                .HasForeignKey(e => e.StoreLocatorId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
