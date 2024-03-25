using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(UnitOfMeasureValidator))]
    public class UnitOfMeasureModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Abbreviation { get; set; }

        public string Description { get; set; }
    }
}