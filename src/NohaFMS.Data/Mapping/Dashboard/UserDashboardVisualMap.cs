/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class UserDashboardVisualMap : NohaFMSEntityTypeConfiguration<UserDashboardVisual>
    {
        public UserDashboardVisualMap()
            : base()
        {
            this.ToTable("UserDashboardVisual");
            this.HasOptional(e => e.UserDashboard)
                .WithMany(e => e.UserDashboardVisuals)
                .HasForeignKey(e => e.UserDashboardId);
            this.HasOptional(e => e.Visual)
                .WithMany()
                .HasForeignKey(e => e.VisualId);
        }
    }
}
