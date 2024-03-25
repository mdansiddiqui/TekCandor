/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class TeamMap : NohaFMSEntityTypeConfiguration<Team>
    {
        public TeamMap()
            : base()
        {
            this.ToTable("Team");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
            this.HasMany(e => e.Technicians)
                .WithMany(e => e.Teams)
                .Map(e =>
                {
                    e.MapLeftKey("TeamId");
                    e.MapRightKey("TechnicianId");
                    e.ToTable("Team_Technician");
                });
        }
    }
}
