/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class ContractPriceItem : BaseEntity
    {
        public long? ContractId { get; set; }
        public virtual Contract Contract { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public decimal? ContractedPrice { get; set; }
    }
}
