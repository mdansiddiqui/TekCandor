/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class SecurityGroupMap : NohaFMSEntityTypeConfiguration<SecurityGroup>
    {
        public SecurityGroupMap()
        {
            this.ToTable("SecurityGroup");
            this.Property(s => s.Description).HasMaxLength(512);
            this.HasMany(e => e.Users)
                .WithMany(e => e.SecurityGroups)
                .Map(e =>
                {
                    e.MapLeftKey("SecurityGroupId");
                    e.MapRightKey("UserId");
                    e.ToTable("SecurityGroup_User");
                });
        }
    }
}
