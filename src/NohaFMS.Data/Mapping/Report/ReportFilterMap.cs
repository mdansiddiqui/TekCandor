/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReportFilterMap : NohaFMSEntityTypeConfiguration<ReportFilter>
    {
        public ReportFilterMap()
            : base()
        {
            this.ToTable("ReportFilter");
            this.Property(e => e.DbColumn).HasMaxLength(64);
            this.Property(e => e.ResourceKey).HasMaxLength(64);
            this.HasOptional(e => e.Report)
                .WithMany(e => e.ReportFilters)
                .HasForeignKey(e => e.ReportId);
            this.HasOptional(e => e.Filter)
                .WithMany()
                .HasForeignKey(e => e.FilterId);
            this.HasOptional(e => e.ParentReportFilter)
                .WithMany()
                .HasForeignKey(e => e.ParentReportFilterId);
        }
    }
}
