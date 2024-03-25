/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class ValueItemCategoryMap : NohaFMSEntityTypeConfiguration<ValueItemCategory>
    {
        public ValueItemCategoryMap()
        {
            this.ToTable("ValueItemCategory");
        }
    }
}
