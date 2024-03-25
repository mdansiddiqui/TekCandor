using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(MeterValidator))]
    public class MeterModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Meter.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Meter.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Meter.MeterType")]
        public long? MeterTypeId { get; set; }
        public ValueItemModel MeterType { get; set; }

        [BaseEamResourceDisplayName("Meter.UnitOfMeasure")]
        public long? UnitOfMeasureId { get; set; }
        public UnitOfMeasureModel UnitOfMeasure { get; set; }
    }
}