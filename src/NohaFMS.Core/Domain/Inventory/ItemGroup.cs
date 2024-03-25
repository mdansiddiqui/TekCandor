/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    [Table("ItemGroup")]
    public class ItemGroup : BaseEntity
    {
        public string Description { get; set; }
    }
}
