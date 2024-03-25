/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class MeterGroup : BaseEntity
    {
        public string Description { get; set; }

        private ICollection<MeterLineItem> _meterLineItems;
        public virtual ICollection<MeterLineItem> MeterLineItems
        {
            get { return _meterLineItems ?? (_meterLineItems = new List<MeterLineItem>()); }
            protected set { _meterLineItems = value; }
        }
    }
}
