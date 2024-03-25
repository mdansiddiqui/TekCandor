using NohaFMS.Web.Framework;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(UnitConversionValidator))]
    public class UnitConversionModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("UnitConversion.FromUnitOfMeasure")]
        public long? FromUnitOfMeasureId { get; set; }
        public UnitOfMeasureModel FromUnitOfMeasure { get; set; }

        [BaseEamResourceDisplayName("UnitConversion.ToUnitOfMeasure")]
        public long? ToUnitOfMeasureId { get; set; }
        public UnitOfMeasureModel ToUnitOfMeasure { get; set; }

        [BaseEamResourceDisplayName("UnitConversion.ConversionFactor")]
        public decimal? ConversionFactor { get; set; }
    }
}