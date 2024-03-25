/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class Reading : BaseEntity
    {
        public long? PointMeterLineItemId { get; set; }
        public virtual PointMeterLineItem PointMeterLineItem { get; set; }

        public decimal? ReadingValue { get; set; }
        public DateTime? DateOfReading { get; set; }

        public int? ReadingSource { get; set; }

        public long? WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
    }

    public enum ReadingSource
    {
        //input from Asset/Location screen
        Directly = 0,
        //input from WorkOrder
        WorkOrder
    }
}
