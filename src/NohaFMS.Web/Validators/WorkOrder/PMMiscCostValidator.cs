/*******************************************************
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
    public class PMMiscCostValidator : BaseEamValidator<PMMiscCostModel>
    {
        private readonly IRepository<PMMiscCost> _pMMiscCostRepository;
        public PMMiscCostValidator(ILocalizationService localizationService, IRepository<PMMiscCost> pMMiscCostRepository)
        {
            this._pMMiscCostRepository = pMMiscCostRepository;

            RuleFor(x => x.Sequence).NotEmpty().WithMessage(localizationService.GetResource("PMMiscCost.Sequence.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("PMMiscCost.Sequence.Unique"));
        }

        private bool NoDuplication(PMMiscCostModel model)
        {
            var pMMiscCost = _pMMiscCostRepository.GetAll().Where(c => c.Sequence == model.Sequence && c.Id != model.Id && c.PreventiveMaintenanceId == model.PreventiveMaintenanceId).FirstOrDefault();
            return pMMiscCost == null;
        }
    }
}