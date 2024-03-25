using NohaFMS.Web.Framework;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ValueItemValidator))]
    public class ValueItemModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("ValueItem.Name")]
        public string Name { get; set; }

        public ValueItemCategoryModel ValueItemCategory { get; set; }
    }
}