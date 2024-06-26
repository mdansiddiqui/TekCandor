﻿using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class TaskValidator : BaseEamValidator<TaskModel>
    {
        private readonly IRepository<Task> _taskRepository;
        public TaskValidator(ILocalizationService localizationService, IRepository<Task> taskRepository)
        {
            this._taskRepository = taskRepository;

            RuleFor(x => x.Sequence).NotEmpty().WithMessage(localizationService.GetResource("Task.Sequence.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Task.Description.Required"));
            //RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Task.Sequence.Unique"));
        }

        private bool NoDuplication(TaskModel model)
        {
            var task = _taskRepository.GetAll().Where(c => c.Sequence == model.Sequence && c.Id != model.Id).FirstOrDefault();
            return task == null;
        }
    }
}