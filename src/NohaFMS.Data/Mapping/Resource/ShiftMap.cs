/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ShiftMap : NohaFMSEntityTypeConfiguration<Shift>
    {
        public ShiftMap()
            : base()
        {
            this.ToTable("Shift");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Calendar)
                .WithMany()
                .HasForeignKey(e => e.CalendarId);
        }
    }
}
