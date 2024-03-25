/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AssignmentGroupUserMap : NohaFMSEntityTypeConfiguration<AssignmentGroupUser>
    {
        public AssignmentGroupUserMap()
        {
            this.ToTable("AssignmentGroupUser");
            this.HasOptional(e => e.AssignmentGroup)
                .WithMany(e => e.AssignmentGroupUsers)
                .HasForeignKey(e => e.AssignmentGroupId);
            this.HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
        }
    }
}
