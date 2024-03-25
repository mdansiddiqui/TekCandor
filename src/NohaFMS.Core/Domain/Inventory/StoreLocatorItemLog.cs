/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Log changes to a store locator item
    /// </summary>
    public class StoreLocatorItemLog : BaseEntity
    {
        public long? StoreLocatorItemId { get; set; }
        public virtual StoreLocatorItem StoreLocatorItem { get; set; }

        public long? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public long? StoreLocatorId { get; set; }
        public virtual StoreLocator StoreLocator { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public DateTime? BatchDate { get; set; }

        public decimal? UnitPrice { get; set; }
        public decimal? QuantityChanged { get; set; }
        public decimal? CostChanged { get; set; }

        //Transaction Details
        public string TransactionType { get; set; }
        public long? TransactionId { get; set; }
        public string TransactionNumber { get; set; }
        public DateTime? TransactionDate { get; set; }        
        public long? TransactionItemId { get; set; }        
    }
}
