/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AddressMap : NohaFMSEntityTypeConfiguration<Address>
    {
        public AddressMap()
        {
            this.ToTable("Address");
            this.Property(e => e.Country).HasMaxLength(256);
            this.Property(e => e.StateProvince).HasMaxLength(256);
            this.Property(e => e.City).HasMaxLength(256);
            this.Property(e => e.Address1).HasMaxLength(256);
            this.Property(e => e.Address2).HasMaxLength(256);
            this.Property(e => e.ZipPostalCode).HasMaxLength(256);
            this.Property(e => e.PhoneNumber).HasMaxLength(256);
            this.Property(e => e.FaxNumber).HasMaxLength(256);
            this.Property(e => e.Email).HasMaxLength(256);
        }
    }
}
