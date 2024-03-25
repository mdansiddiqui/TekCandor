/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class StoreMap : NohaFMSEntityTypeConfiguration<Store>
    {
        public StoreMap()
        {
            this.ToTable("Store");
            this.Property(s => s.Description).HasMaxLength(512);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
            this.HasOptional(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId);
            this.HasOptional(e => e.StoreType)
                .WithMany()
                .HasForeignKey(e => e.StoreTypeId);
        }
    }
}
