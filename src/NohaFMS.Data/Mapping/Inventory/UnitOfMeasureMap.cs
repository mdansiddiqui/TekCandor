/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class UnitOfMeasureMap : NohaFMSEntityTypeConfiguration<UnitOfMeasure>
    {
        public UnitOfMeasureMap()
        {
            this.ToTable("UnitOfMeasure");
            this.Property(s => s.Abbreviation).HasMaxLength(64);
            this.Property(s => s.Description).HasMaxLength(128);
        }
    }
}
