/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CalendarMap : NohaFMSEntityTypeConfiguration<Calendar>
    {
        public CalendarMap()
            : base()
        {
            this.ToTable("Calendar");
            this.Property(s => s.Description).HasMaxLength(512);
        }
    }
}
