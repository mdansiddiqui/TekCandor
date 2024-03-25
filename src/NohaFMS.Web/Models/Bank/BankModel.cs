using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    // [Validator(typeof(AttributeValidator))]
    public class BankModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("System.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("System.Code")]
        public string Code { get; set; }

    }
}