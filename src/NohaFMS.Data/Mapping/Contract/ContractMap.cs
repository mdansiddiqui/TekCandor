/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ContractMap : NohaFMSWorkflowEntityTypeConfiguration<Contract>
    {
        public ContractMap()
            : base()
        {
            this.ToTable("Contract");
            this.Property(e => e.Total).HasPrecision(19, 4);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
            this.HasOptional(e => e.WorkCategory)
                .WithMany()
                .HasForeignKey(e => e.WorkCategoryId);
            this.HasOptional(e => e.WorkType)
                .WithMany()
                .HasForeignKey(e => e.WorkTypeId);
            this.HasOptional(e => e.Vendor)
                .WithMany()
                .HasForeignKey(e => e.VendorId);
            this.HasOptional(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId);
        }
    }
}
