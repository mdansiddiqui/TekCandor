/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// When issuing an item, based on item's costing type (LIFO, FIFO, etc)
    /// we need to find the corresponding store locator'items to remove
    /// and need to specified price, quantity, cost of the removal item
    /// StoreLocatorItemRemoval is used to keep track of these information
    /// </summary>
    public class StoreLocatorItemRemoval
    {
        public decimal? UnitPrice { get; set; }
        public decimal? Quantity { get; set; }
        public decimal? Cost { get; set; }
    }
}
