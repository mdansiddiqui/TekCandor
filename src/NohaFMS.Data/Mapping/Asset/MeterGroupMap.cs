/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MeterGroupMap : NohaFMSEntityTypeConfiguration<MeterGroup>
    {
        public MeterGroupMap()
        {
            this.ToTable("MeterGroup");
            this.Property(s => s.Description).HasMaxLength(512);
        }
    }
}
