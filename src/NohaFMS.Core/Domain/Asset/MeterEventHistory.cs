/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class MeterEventHistory : BaseEntity
    {
        public long? MeterEventId { get; set; }
        public virtual MeterEvent MeterEvent { get; set; }

        public decimal? GeneratedReading { get; set; }
        public bool IsWorkOrderCreated { get; set; }
    }
}
