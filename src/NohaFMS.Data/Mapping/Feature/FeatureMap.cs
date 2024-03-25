/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class FeatureMap : NohaFMSEntityTypeConfiguration<Feature>
    {
        public FeatureMap()
        {
            this.ToTable("Feature");
            this.Property(s => s.Description).HasMaxLength(512);
            this.Property(s => s.EntityType).HasMaxLength(64);
            this.HasOptional(e => e.Module)
                .WithMany(e => e.Features)
                .HasForeignKey(e => e.ModuleId)
                .WillCascadeOnDelete(true);
        }
    }
}
