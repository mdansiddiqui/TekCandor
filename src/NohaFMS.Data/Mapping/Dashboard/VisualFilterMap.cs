/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class VisualFilterMap : NohaFMSEntityTypeConfiguration<VisualFilter>
    {
        public VisualFilterMap()
            : base()
        {
            this.ToTable("VisualFilter");
            this.Property(e => e.DbColumn).HasMaxLength(64);
            this.Property(e => e.ResourceKey).HasMaxLength(64);
            this.HasOptional(e => e.Visual)
                .WithMany(e => e.VisualFilters)
                .HasForeignKey(e => e.VisualId);
            this.HasOptional(e => e.Filter)
                .WithMany()
                .HasForeignKey(e => e.FilterId);
            this.HasOptional(e => e.ParentVisualFilter)
                .WithMany()
                .HasForeignKey(e => e.ParentVisualFilterId);
        }
    }
}
