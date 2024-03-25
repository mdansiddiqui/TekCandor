﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class StoreItem : BaseEntity
    {
        public long? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public int? StockType { get; set; }
        public int? LotType { get; set; }
        public int? CostingType { get; set; }

        public decimal? StandardCostingUnitPrice { get; set; }

        public decimal? SafetyStock { get; set; }
        public decimal? ReorderPoint { get; set; }
        public decimal? EconomicOrderQuantity { get; set; }
    }
}
