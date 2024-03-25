/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class Shift : BaseEntity
    {
        public string Description { get; set; }

        public long? CalendarId { get; set; }
        public virtual Calendar Calendar { get; set; }

        public int? StartDay { get; set; }
        public int? DaysInPattern { get; set; }

        private ICollection<ShiftPattern> _shiftPatterns;
        public virtual ICollection<ShiftPattern> ShiftPatterns
        {
            get { return _shiftPatterns ?? (_shiftPatterns = new List<ShiftPattern>()); }
            protected set { _shiftPatterns = value; }
        }
    }

    public enum WeekDay
    {
        Sunday = 0,
        Monday,
        Tuesday,
        Wednesday,
        Thursday,
        Friday,
        Saturday
    }
}
