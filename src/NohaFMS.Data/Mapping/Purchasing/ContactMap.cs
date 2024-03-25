/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ContactMap : NohaFMSEntityTypeConfiguration<Contact>
    {
        public ContactMap()
            : base()
        {
            this.ToTable("Contact");
            this.Property(e => e.Position).HasMaxLength(64);
            this.Property(e => e.Email).HasMaxLength(64);
            this.Property(e => e.Phone).HasMaxLength(64);
            this.Property(e => e.Fax).HasMaxLength(64);
            this.HasOptional(e => e.Company)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.CompanyId);
            this.HasOptional(e => e.Contract)
                .WithMany(e => e.Contacts)
                .HasForeignKey(e => e.ContractId);
        }
    }
}
