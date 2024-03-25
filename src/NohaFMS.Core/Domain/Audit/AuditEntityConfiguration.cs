/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain
{
    [Table("AuditEntityConfiguration")]
    public class AuditEntityConfiguration : BaseEntity
    {
        public string EntityType { get; set; }

        /// <summary>
        /// The list of columns seperated by ','
        /// that will not be audited
        /// </summary>
        public string ExcludedColumns { get; set; }
    }
}
