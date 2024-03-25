/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class FeatureActionMap : NohaFMSEntityTypeConfiguration<FeatureAction>
    {
        public FeatureActionMap()
        {
            this.ToTable("FeatureAction");
            this.Property(s => s.Description).HasMaxLength(512);
            this.HasOptional(e => e.Feature)
                .WithMany(e => e.FeatureActions)
                .HasForeignKey(e => e.FeatureId)
                .WillCascadeOnDelete(true);
        }
    }
}
