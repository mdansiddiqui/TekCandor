/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class UnitConversion : BaseEntity
    {
        public long? FromUnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure FromUnitOfMeasure { get; set; }

        public long? ToUnitOfMeasureId { get; set; }
        public virtual UnitOfMeasure ToUnitOfMeasure { get; set; }

        public decimal? ConversionFactor { get; set; }
    }
}
