/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class PermissionRecordMap : NohaFMSEntityTypeConfiguration<PermissionRecord>
    {
        public PermissionRecordMap()
        {
            this.ToTable("PermissionRecord");
            this.HasOptional(e => e.Module)
                .WithMany()
                .HasForeignKey(e => e.ModuleId)
                .WillCascadeOnDelete(true);
            this.HasOptional(e => e.Feature)
                .WithMany()
                .HasForeignKey(e => e.FeatureId)
                .WillCascadeOnDelete(true);
            this.HasOptional(e => e.FeatureAction)
                .WithMany()
                .HasForeignKey(e => e.FeatureActionId)
                .WillCascadeOnDelete(true);
            this.HasMany(e => e.SecurityGroups)
                .WithMany(e => e.PermissionRecords)
                .Map(e =>
                {
                    e.MapLeftKey("PermissionRecordId");
                    e.MapRightKey("SecurityGroupId");
                    e.ToTable("SecurityGroup_PermissionRecord");
                });
        }
    }
}
