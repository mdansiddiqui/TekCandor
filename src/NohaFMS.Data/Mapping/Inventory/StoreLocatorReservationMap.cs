/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreLocatorReservationMap : NohaFMSEntityTypeConfiguration<StoreLocatorReservation>
    {
        public StoreLocatorReservationMap()
        {
            this.ToTable("StoreLocatorReservation");
            this.Property(e => e.QuantityReserved).HasPrecision(19, 4);
            this.HasOptional(e => e.StoreLocator)
                .WithMany()
                .HasForeignKey(e => e.StoreLocatorId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
