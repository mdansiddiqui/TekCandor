/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Data.Mapping
{
    public class AttributeMap : NohaFMSEntityTypeConfiguration<Core.Domain.Attribute>
    {
        public AttributeMap()
        {
            this.ToTable("Attribute");
            this.Property(s => s.ResourceKey).HasMaxLength(64);
            this.Property(s => s.CsvTextList).HasMaxLength(2048);
            this.Property(s => s.CsvValueList).HasMaxLength(2048);
        }
    }
}
