/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class EntityAttribute : BaseEntity
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
        public int? DisplayOrder { get; set; }
        public string Value { get; set; }
        public bool IsRequiredField { get; set; }

        public long? AttributeId { get; set; }
        public virtual Attribute Attribute { get; set; }
    }
}
