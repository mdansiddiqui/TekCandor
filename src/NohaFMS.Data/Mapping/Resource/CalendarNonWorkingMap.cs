/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CalendarNonWorkingMap : NohaFMSEntityTypeConfiguration<CalendarNonWorking>
    {
        public CalendarNonWorkingMap()
            : base()
        {
            this.ToTable("CalendarNonWorking");
            this.HasOptional(e => e.Calendar)
                .WithMany(e => e.CalendarNonWorkings)
                .HasForeignKey(e => e.CalendarId)
                .WillCascadeOnDelete(true);
        }
    }
}
