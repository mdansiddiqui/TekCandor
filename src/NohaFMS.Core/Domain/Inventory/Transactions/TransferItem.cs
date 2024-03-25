/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class TransferItem : BaseEntity
    {
        public long? TransferId { get; set; }
        public virtual Transfer Transfer { get; set; }

        public long? FromStoreLocatorId { get; set; }
        public virtual StoreLocator FromStoreLocator { get; set; }

        public long? ToStoreLocatorId { get; set; }
        public virtual StoreLocator ToStoreLocator { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        public decimal? TransferQuantity { get; set; }

        /// <summary>
        /// This can be different than Item's default UOM
        /// Use UnitConversion to convert
        /// </summary>
        public long? TransferUnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure TransferUnitOfMeasure { get; set; }

        public decimal? TransferCost { get; set; }
    }
}
