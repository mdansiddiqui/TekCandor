﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class PMTaskValidator : BaseEamValidator<PMTaskModel>
    {
        private readonly IRepository<PMTask> _pMTaskRepository;
        public PMTaskValidator(ILocalizationService localizationService, IRepository<PMTask> pMTaskRepository)
        {
            this._pMTaskRepository = pMTaskRepository;

            RuleFor(x => x.Sequence).NotEmpty().WithMessage(localizationService.GetResource("PMTask.Sequence.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("PMTask.Description.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("PMTask.Sequence.Unique"));
        }

        private bool NoDuplication(PMTaskModel model)
        {
            var pMTask = _pMTaskRepository.GetAll().Where(c => c.Sequence == model.Sequence && c.Id != model.Id && c.PreventiveMaintenanceId == model.PreventiveMaintenanceId).FirstOrDefault();
            return pMTask == null;
        }
    }
}