/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class MeterLineItem : BaseEntity
    {
        public int DisplayOrder { get; set; }

        public long? MeterGroupId { get; set; }
        public virtual MeterGroup MeterGroup { get; set; }

        public long? MeterId { get; set; }
        public virtual Meter Meter { get; set; }
    }
}
