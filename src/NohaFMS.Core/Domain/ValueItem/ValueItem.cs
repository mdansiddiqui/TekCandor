/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    [Table("ValueItem")]
    public partial class ValueItem : BaseEntity
    {
        public long? ValueItemCategoryId { get; set; }
        [Dapper.Contrib.Extensions.Write(false)]
        public virtual ValueItemCategory ValueItemCategory { get; set; }
    }
}
    