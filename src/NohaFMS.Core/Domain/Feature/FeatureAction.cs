/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// A feature action represents an action in feature 
    /// such as: Create, View, Edit, ...
    /// </summary>
    public partial class FeatureAction : BaseEntity
    {
        public string Description { get; set; }
        public int DisplayOrder { get; set; }

        public long? FeatureId { get; set; }
        public virtual Feature Feature { get; set; }
    }
}
