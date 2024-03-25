/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReportColumnMap : NohaFMSEntityTypeConfiguration<ReportColumn>
    {
        public ReportColumnMap()
            : base()
        {
            this.ToTable("ReportColumn");
            this.Property(e => e.ColumnName).HasMaxLength(64);
            this.Property(e => e.DataType).HasMaxLength(64);
            this.Property(e => e.FormatString).HasMaxLength(64);
            this.Property(e => e.ResourceKey).HasMaxLength(64);
            this.HasOptional(e => e.Report)
                .WithMany(e => e.ReportColumns)
                .HasForeignKey(e => e.ReportId);
        }
    }
}
