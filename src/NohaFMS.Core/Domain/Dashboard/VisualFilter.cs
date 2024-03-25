/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class VisualFilter : BaseEntity
    {
        public long? VisualId { get; set; }
        public virtual Visual Visual { get; set; }

        public long? FilterId { get; set; }
        public virtual Filter Filter { get; set; }

        public int? DisplayOrder { get; set; }

        public string DbColumn { get; set; }
        public bool IsRequired { get; set; }

        /// <summary>
        /// ResourceKey overidden from Filter
        /// </summary>
        public string ResourceKey { get; set; }

        public long? ParentVisualFilterId { get; set; }
        public virtual ReportFilter ParentVisualFilter { get; set; }
    }
}
