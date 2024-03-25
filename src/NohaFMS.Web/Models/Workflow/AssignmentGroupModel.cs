using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(AssignmentGroupValidator))]
    public class AssignmentGroupModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("AssignmentGroup.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("AssignmentGroup.Description")]
        public string Description { get; set; }
    }
}