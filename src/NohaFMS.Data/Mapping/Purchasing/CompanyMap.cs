/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CompanyMap : NohaFMSEntityTypeConfiguration<Company>
    {
        public CompanyMap()
            : base()
        {
            this.ToTable("Company");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.Website).HasMaxLength(128);
            this.HasOptional(e => e.CompanyType)
                .WithMany()
                .HasForeignKey(e => e.CompanyTypeId);
            this.HasOptional(e => e.Currency)
                .WithMany()
                .HasForeignKey(e => e.CurrencyId);
            this.HasMany(e => e.Addresses)
                .WithMany()
                .Map(e =>
                {
                    e.MapLeftKey("CompanyId");
                    e.MapRightKey("AddressId");
                    e.ToTable("Company_Address");
                });
        }
    }
}
