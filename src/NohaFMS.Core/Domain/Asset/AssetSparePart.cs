/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class AssetSparePart : BaseEntity
    {
        public long? AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public long? ItemId { get; set; }
        public virtual Item Item { get; set; }

        /// <summary>
        /// The quantity of parts required for this asset
        /// </summary>
        public decimal? Quantity { get; set; }
    }
}
