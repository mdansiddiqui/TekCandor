/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class StoreLocatorReservation : BaseEntity
    {
        public long? StoreLocatorId { get; set; }
        public virtual StoreLocator StoreLocator { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public decimal? QuantityReserved { get; set; }
    }
}
