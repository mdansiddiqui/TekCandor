/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;


namespace NohaFMS.Data.Mapping
{
    public class AutoNumberMap : NohaFMSEntityTypeConfiguration<AutoNumber>
    {
        public AutoNumberMap()
        {
            this.ToTable("AutoNumber");
            this.Property(s => s.EntityType).HasMaxLength(64);
        }
    }
}
