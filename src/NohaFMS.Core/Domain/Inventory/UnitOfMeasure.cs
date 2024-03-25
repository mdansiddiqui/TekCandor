/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain
{
    [Table("UnitOfMeasure")]
    public class UnitOfMeasure : BaseEntity
    {
        public string Abbreviation { get; set; }
        public string Description { get; set; }
    }
}
