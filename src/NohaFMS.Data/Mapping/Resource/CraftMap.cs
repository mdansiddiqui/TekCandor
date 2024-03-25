/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CraftMap : NohaFMSEntityTypeConfiguration<Craft>
    {
        public CraftMap()
            : base()
        {
            this.ToTable("Craft");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.StandardRate).HasPrecision(19, 4);
            this.Property(e => e.OvertimeRate).HasPrecision(19, 4);
        }
    }
}
