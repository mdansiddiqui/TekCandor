/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class CalendarNonWorking : BaseEntity
    {
        public long? CalendarId { get; set; }
        public virtual Calendar Calendar { get; set; }

        public DateTime? NonWorkingDate { get; set; }
    }
}
