using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(WorkflowDefinitionValidator))]
    public class WorkflowDefinitionModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("WorkflowDefinition.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("WorkflowDefinition.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("WorkflowDefinition.IsDefault")]
        public bool IsDefault { get; set; }
    }
}