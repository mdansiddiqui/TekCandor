﻿using NohaFMS.Web.Framework;

namespace NohaFMS.Web.Models
{
    public class EntityHubModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.Entity")]
        public long? EntityId { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.DisplayOrder")]
        public int? DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.Value")]
        public string Value { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.IsRequiredField")]
        public bool IsRequiredField { get; set; }

        [BaseEamResourceDisplayName("EntityAttribute.Attribute")]
        public long? AttributeId { get; set; }
        public AttributeModel Attribute { get; set; }
    }
}