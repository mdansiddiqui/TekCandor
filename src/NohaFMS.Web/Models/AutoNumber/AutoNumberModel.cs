using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(AutoNumberValidator))]
    public class AutoNumberModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("AutoNumber.EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("AutoNumber.FormatString")]
        public string FormatString { get; set; }
    }
}