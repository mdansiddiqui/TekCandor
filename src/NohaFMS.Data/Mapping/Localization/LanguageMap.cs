/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class LanguageMap : NohaFMSEntityTypeConfiguration<Language>
    {
        public LanguageMap()
            :base()
        {
            this.ToTable("Language");
            this.Property(l => l.LanguageCulture).HasMaxLength(20);
            this.Property(l => l.FlagImageFileName).HasMaxLength(50);
        }
    }
}