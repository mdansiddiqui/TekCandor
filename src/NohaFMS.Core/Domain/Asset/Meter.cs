/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain
{
    [Table("Meter")]
    public class Meter : BaseEntity
    {
        public string Description { get; set; }

        public long? MeterTypeId { get; set; }
        [Write(false)]
        public virtual ValueItem MeterType { get; set; }

        public long? UnitOfMeasureId { get; set; }
        [Write(false)]
        public virtual UnitOfMeasure UnitOfMeasure { get; set; }
    }
}
