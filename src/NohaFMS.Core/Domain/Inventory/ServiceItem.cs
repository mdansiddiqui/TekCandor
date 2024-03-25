/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class ServiceItem : BaseEntity
    {
        public string Description { get; set; }
        public decimal? UnitPrice { get; set; }

        public long? ItemGroupId { get; set; }
        public virtual ItemGroup ItemGroup { get; set; }

        public bool IsActive { get; set; }
    }
}
