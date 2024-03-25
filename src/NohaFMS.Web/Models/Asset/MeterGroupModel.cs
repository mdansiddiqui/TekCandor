using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(MeterGroupValidator))]
    public class MeterGroupModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("MeterGroup.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("MeterGroup.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("MeterGroup.Description")]
        public string Description { get; set; }
    }
}