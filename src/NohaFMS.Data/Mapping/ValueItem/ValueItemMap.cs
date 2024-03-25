/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class ValueItemMap : NohaFMSEntityTypeConfiguration<ValueItem>
    {
        public ValueItemMap()
        {
            this.ToTable("ValueItem");
            this.HasOptional(e => e.ValueItemCategory)
                .WithMany(e => e.ValueItems)
                .HasForeignKey(e => e.ValueItemCategoryId)
                .WillCascadeOnDelete(true);
        }
    }
}
