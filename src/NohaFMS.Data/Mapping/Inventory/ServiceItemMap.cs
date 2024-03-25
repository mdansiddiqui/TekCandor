/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ServiceItemMap : NohaFMSEntityTypeConfiguration<ServiceItem>
    {
        public ServiceItemMap()
        {
            this.ToTable("ServiceItem");
            this.Property(s => s.Description).HasMaxLength(512);
            this.Property(e => e.UnitPrice).HasPrecision(19, 4);
            this.HasOptional(e => e.ItemGroup)
                .WithMany()
                .HasForeignKey(e => e.ItemGroupId);
        }
    }
}
