/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class UserMap : NohaFMSEntityTypeConfiguration<User>
    {
        public UserMap()
        {
            this.ToTable("User");
            this.Property(e => e.LoginName).HasMaxLength(128);
            this.Property(e => e.LoginPassword).HasMaxLength(128);
            this.Property(e => e.Email).HasMaxLength(128);
            this.Property(e => e.TimeZoneId).HasMaxLength(128);
            this.Property(e => e.AddressCountry).HasMaxLength(256);
            this.Property(e => e.AddressState).HasMaxLength(256);
            this.Property(e => e.AddressCity).HasMaxLength(256);
            this.Property(e => e.Address).HasMaxLength(256);
            this.Property(e => e.Phone).HasMaxLength(128);
            this.Property(e => e.Cellphone).HasMaxLength(128);
            this.Property(e => e.Fax).HasMaxLength(128);
            this.Property(u => u.ActiveDirectoryDomain).HasMaxLength(128);
            this.Property(u => u.LastIpAddress).HasMaxLength(128);
            this.Property(u => u.PublicKey).HasMaxLength(256);
            this.Property(u => u.SecretKey).HasMaxLength(256);
            this.Property(e => e.POApprovalLimit).HasPrecision(19, 4);
            this.Property(u => u.Hubids).HasMaxLength(128);
            this.Property(u => u.BranchIds).HasMaxLength(128);
            this.HasOptional(e => e.Supervisor)
                .WithMany()
                .HasForeignKey(e => e.SupervisorId);
            this.HasOptional(e => e.Language)
                .WithMany()
                .HasForeignKey(e => e.LanguageId);
            this.HasOptional(e => e.DefaultSite)
                .WithMany()
                .HasForeignKey(e => e.DefaultSiteId);
            this.HasRequired(e => e.Organization)
                .WithMany()
                .HasForeignKey(e => e.OrganizationId);
        }
    }
}
