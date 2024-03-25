/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class ReportFilter : BaseEntity
    {
        public long? ReportId { get; set; }
        public virtual Report Report { get; set; }

        public long? FilterId { get; set; }
        public virtual Filter Filter { get; set; }

        public int? DisplayOrder { get; set; }

        public string DbColumn { get; set; }
        public bool IsRequired { get; set; }

        /// <summary>
        /// ResourceKey overidden from Filter
        /// </summary>
        public string ResourceKey { get; set; }

        public long? ParentReportFilterId { get; set; }
        public virtual ReportFilter ParentReportFilter { get; set; }
    }
}
