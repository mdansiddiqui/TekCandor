/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class OrganizationMap : NohaFMSEntityTypeConfiguration<Organization>
    {
        public OrganizationMap()
        {
            this.ToTable("Organization");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasMany(e => e.Addresses)
                .WithMany()
                .Map(e =>
                {
                    e.MapLeftKey("OrganizationId");
                    e.MapRightKey("AddressId");
                    e.ToTable("Organization_Address");
                });
        }
    }
}
