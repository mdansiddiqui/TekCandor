/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class LocaleStringResourceMap : NohaFMSEntityTypeConfiguration<LocaleStringResource>
    {
        public LocaleStringResourceMap()
            :base()
        {
            this.ToTable("LocaleStringResource");
            this.Property(lsr => lsr.ResourceName).IsRequired().HasMaxLength(200);
            this.Property(lsr => lsr.ResourceValue).IsRequired();
            this.HasRequired(lsr => lsr.Language)
                .WithMany(l => l.LocaleStringResources)
                .HasForeignKey(lsr => lsr.LanguageId)
                .WillCascadeOnDelete(true);
        }
    }
}