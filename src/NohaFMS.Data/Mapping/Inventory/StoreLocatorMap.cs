/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreLocatorMap : NohaFMSEntityTypeConfiguration<StoreLocator>
    {
        public StoreLocatorMap()
        {
            this.ToTable("StoreLocator");
            this.HasOptional(e => e.Store)
                .WithMany(e => e.StoreLocators)
                .HasForeignKey(e => e.StoreId);
        }
    }
}
