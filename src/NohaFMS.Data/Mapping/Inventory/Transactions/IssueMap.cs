/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class IssueMap : NohaFMSEntityTypeConfiguration<Issue>
    {
        public IssueMap()
        {
            this.ToTable("Issue");
            this.Property(s => s.Number).HasMaxLength(64);
            this.Property(s => s.Description).HasMaxLength(512);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
            this.HasOptional(e => e.Store)
                .WithMany()
                .HasForeignKey(e => e.StoreId);
            this.HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
            this.HasOptional(e => e.WorkOrder)
                .WithMany()
                .HasForeignKey(e => e.WorkOrderId);
        }
    }
}
