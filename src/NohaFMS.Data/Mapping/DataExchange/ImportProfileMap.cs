/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ImportProfileMap : NohaFMSEntityTypeConfiguration<ImportProfile>
    {
        public ImportProfileMap()
            : base()
        {
            this.ToTable("ImportProfile");
            this.Property(e => e.ImportFileName).HasMaxLength(128);
            this.Property(e => e.LogFileName).HasMaxLength(128);
        }
    }
}
