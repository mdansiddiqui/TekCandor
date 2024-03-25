using System.Linq;
using FluentValidation;
using NohaFMS.Web.Models;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;

namespace NohaFMS.Web.Validators
{
    public class WorkflowDefinitionValidator : BaseEamValidator<WorkflowDefinitionModel>
    {
        private readonly IRepository<WorkflowDefinition> _workflowDefinitionRepository;
        public WorkflowDefinitionValidator(ILocalizationService localizationService, IRepository<WorkflowDefinition> workflowDefinitionRepository)
        {
            this._workflowDefinitionRepository = workflowDefinitionRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("WorkflowDefinition.Name.Required"));
            RuleFor(x => x.EntityType).NotEmpty().WithMessage(localizationService.GetResource("EntityType.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("WorkflowDefinition.Name.Unique"));
            RuleFor(x => x).Must(OnlyOneDefaultForEntityType).WithMessage(localizationService.GetResource("WorkflowDefinition.IsDefault.Unique"));
        }

        private bool NoDuplication(WorkflowDefinitionModel model)
        {
            var workflowDefinition = _workflowDefinitionRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return workflowDefinition == null;
        }

        private bool OnlyOneDefaultForEntityType(WorkflowDefinitionModel model)
        {
            if(model.IsDefault == true)
            {
                var workflowDefinition = _workflowDefinitionRepository.GetAll()
                .Where(c => c.EntityType == model.EntityType && c.IsDefault == true && c.Id != model.Id).FirstOrDefault();
                return workflowDefinition == null;
            }
            return true;
        }
    }
}