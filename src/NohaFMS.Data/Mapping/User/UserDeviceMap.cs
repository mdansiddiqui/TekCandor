/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class UserDeviceMap : NohaFMSEntityTypeConfiguration<UserDevice>
    {
        public UserDeviceMap()
        {
            this.ToTable("UserDevice");
            this.HasOptional(e => e.User)
                .WithMany(e => e.UserDevices)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);
            this.Property(e => e.Platform).HasMaxLength(128);
            this.Property(e => e.DeviceType).HasMaxLength(128);
            this.Property(e => e.DeviceToken).HasMaxLength(256);
        }
    }
}
