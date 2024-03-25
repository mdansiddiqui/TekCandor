using NohaFMS.Web.Framework;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ValueItemCategoryValidator))]
    public class ValueItemCategoryModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("ValueItemCategory.Name")]
        public string Name { get; set; }
    }
}