/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ShiftPatternMap : NohaFMSEntityTypeConfiguration<ShiftPattern>
    {
        public ShiftPatternMap()
            : base()
        {
            this.ToTable("ShiftPattern");
            this.HasOptional(e => e.Shift)
                .WithMany(e => e.ShiftPatterns)
                .HasForeignKey(e => e.ShiftId);
        }
    }
}
