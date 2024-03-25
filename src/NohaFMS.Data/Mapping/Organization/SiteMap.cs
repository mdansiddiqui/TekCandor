/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class SiteMap : NohaFMSEntityTypeConfiguration<Site>
    {
        public SiteMap()
        {
            this.ToTable("Site");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Organization)
                .WithMany(e => e.Sites)
                .HasForeignKey(e => e.OrganizationId)
                .WillCascadeOnDelete(true);
            this.HasMany(e => e.SecurityGroups)
                .WithMany(e => e.Sites)
                .Map(e =>
                {
                    e.MapLeftKey("SiteId");
                    e.MapRightKey("SecurityGroupId");
                    e.ToTable("Site_SecurityGroup");
                });
            this.HasMany(e => e.Addresses)
                .WithMany()
                .Map(e =>
                {
                    e.MapLeftKey("SiteId");
                    e.MapRightKey("AddressId");
                    e.ToTable("Site_Address");
                });
        }
    }
}
