/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class UserPasswordHistoryMap : NohaFMSEntityTypeConfiguration<UserPasswordHistory>
    {
        public UserPasswordHistoryMap()
        {
            this.ToTable("UserPasswordHistory");
            this.Property(e => e.LoginPassword).HasMaxLength(128);
            this.HasOptional(e => e.Owner)
                .WithMany(e => e.PasswordHistory)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}
