/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class StoreItemBalance
    {
        public string StoreItemId { get; set; }
        public long? SiteId { get; set; }
        public string SiteName { get; set; }
        public long? StoreId { get; set; }
        public string StoreName { get; set; }
        public long? ItemId { get; set; }
        public string ItemName { get; set; }
        public int? StoreItemStockType { get; set; }
        public string StoreItemStockTypeText { get; set; }
        public string ItemUnitOfMeasureName { get; set; }
        public decimal? TotalQuantity { get; set; } //sum up
        public decimal? TotalCost { get; set; } //sum up
    }
}
