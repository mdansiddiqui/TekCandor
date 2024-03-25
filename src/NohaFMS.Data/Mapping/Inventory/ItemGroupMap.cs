/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ItemGroupMap : NohaFMSEntityTypeConfiguration<ItemGroup>
    {
        public ItemGroupMap()
        {
            this.ToTable("ItemGroup");
            this.Property(s => s.Description).HasMaxLength(512);
        }
    }
}
