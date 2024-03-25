/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class UserDashboardMap : NohaFMSEntityTypeConfiguration<UserDashboard>
    {
        public UserDashboardMap()
            : base()
        {
            this.ToTable("UserDashboard");
            this.HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
        }
    }
}
