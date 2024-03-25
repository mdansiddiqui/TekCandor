/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class StoreLocatorItemAdjustment
    {
        public long? StoreLocatorId { get; set; }
        public string StoreLocatorName { get; set; }
        public long? ItemId { get; set; }
        public string ItemName { get; set; }
        public decimal? Quantity { get; set; }
    }
}
