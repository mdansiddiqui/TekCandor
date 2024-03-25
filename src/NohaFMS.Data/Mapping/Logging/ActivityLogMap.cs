/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class ActivityLogMap : NohaFMSEntityTypeConfiguration<ActivityLog>
    {
        public ActivityLogMap()
        {
            this.ToTable("ActivityLog");
            this.Property(al => al.Comment).HasMaxLength(256);
            this.HasRequired(al => al.ActivityLogType)
                .WithMany()
                .HasForeignKey(al => al.ActivityLogTypeId)
                .WillCascadeOnDelete(true);
            this.HasRequired(al => al.User)
                .WithMany()
                .HasForeignKey(al => al.UserId);
        }
    }
}
