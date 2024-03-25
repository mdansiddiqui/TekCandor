/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class TechnicianMap : NohaFMSEntityTypeConfiguration<Technician>
    {
        public TechnicianMap()
            : base()
        {
            this.ToTable("Technician");
            this.HasOptional(e => e.User)
                .WithMany()
                .HasForeignKey(e => e.UserId);
            this.HasOptional(e => e.Calendar)
                .WithMany()
                .HasForeignKey(e => e.CalendarId);
            this.HasOptional(e => e.Shift)
                .WithMany()
                .HasForeignKey(e => e.ShiftId);
            this.HasOptional(e => e.Craft)
                .WithMany()
                .HasForeignKey(e => e.CraftId);
        }
    }
}
