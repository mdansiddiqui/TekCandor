/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class VisualMap : NohaFMSEntityTypeConfiguration<Visual>
    {
        public VisualMap()
            : base()
        {
            this.ToTable("Visual");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.XAxis).HasMaxLength(64);
            this.Property(e => e.YAxis).HasMaxLength(64);
            this.Property(e => e.SortExpression).HasMaxLength(64);
            this.HasMany(e => e.SecurityGroups)
                .WithMany(e => e.Visuals)
                .Map(e =>
                {
                    e.MapLeftKey("VisualId");
                    e.MapRightKey("SecurityGroupId");
                    e.ToTable("Visual_SecurityGroup");
                });
        }
    }
}
