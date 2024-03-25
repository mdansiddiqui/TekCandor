/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class ShiftPattern : BaseEntity
    {
        public int? Sequence { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public long? ShiftId { get; set; }
        public virtual Shift Shift { get; set; }
    }
}
