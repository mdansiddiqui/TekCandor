/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReportMap : NohaFMSEntityTypeConfiguration<Report>
    {
        public ReportMap()
            : base()
        {
            this.ToTable("Report");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.Type).HasMaxLength(64);
            this.Property(e => e.TemplateFileName).HasMaxLength(64);
            this.Property(e => e.SortExpression).HasMaxLength(64);
            this.HasMany(e => e.SecurityGroups)
                .WithMany(e => e.Reports)
                .Map(e =>
                {
                    e.MapLeftKey("ReportId");
                    e.MapRightKey("SecurityGroupId");
                    e.ToTable("Report_SecurityGroup");
                });
        }
    }
}
