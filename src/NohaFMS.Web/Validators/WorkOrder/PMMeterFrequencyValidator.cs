/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System.Linq;

namespace NohaFMS.Web.Validators
{
    public class PMMeterFrequencyValidator : BaseEamValidator<PMMeterFrequencyModel>
    {
        private readonly IRepository<PMMeterFrequency> _pMMeterFrequencyRepository;
        public PMMeterFrequencyValidator(ILocalizationService localizationService, IRepository<PMMeterFrequency> pMMeterFrequencyRepository)
        {
            this._pMMeterFrequencyRepository = pMMeterFrequencyRepository;
            RuleFor(x => x.MeterId).NotEmpty().WithMessage(localizationService.GetResource("Meter.Required"));
            RuleFor(x => x.Frequency).NotEmpty().WithMessage(localizationService.GetResource("PMMeterFrequency.Frequency.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Meter.Unique"));
        }

        private bool NoDuplication(PMMeterFrequencyModel model)
        {
            var pMMeterFrequency = _pMMeterFrequencyRepository.GetAll().Where(c => c.MeterId == model.MeterId && c.Id != model.Id && c.PreventiveMaintenanceId == model.PreventiveMaintenanceId).FirstOrDefault();
            return pMMeterFrequency == null;
        }
    }
}