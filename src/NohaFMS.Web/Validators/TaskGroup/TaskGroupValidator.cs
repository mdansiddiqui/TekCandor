using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class TaskGroupValidator : BaseEamValidator<TaskGroupModel>
    {
        private readonly IRepository<TaskGroup> _taskGroupRepository;
        public TaskGroupValidator(ILocalizationService localizationService, IRepository<TaskGroup> taskGroupRepository)
        {
            this._taskGroupRepository = taskGroupRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("TaskGroup.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("TaskGroup.Name.Unique"));
        }

        private bool NoDuplication(TaskGroupModel model)
        {
            var taskGroup = _taskGroupRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return taskGroup == null;
        }
    }
}