/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class CurrencyMap : NohaFMSEntityTypeConfiguration<Currency>
    {
        public CurrencyMap()
            : base()
        {
            this.ToTable("Currency");
            this.Property(e => e.CurrencyCode).HasMaxLength(64);
            this.Property(e => e.DisplayLocale).HasMaxLength(64);
            this.Property(e => e.CustomFormatting).HasMaxLength(64);
            this.Property(e => e.Description).HasMaxLength(128);
            this.Ignore(e => e.CurrencySymbol);
            this.Property(e => e.Rate).HasPrecision(19, 4);
        }
    }
}
