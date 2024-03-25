/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class PMLaborValidator : BaseEamValidator<PMLaborModel>
    {
        public PMLaborValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.TeamId).NotEmpty().WithMessage(localizationService.GetResource("Team.Required"));
            RuleFor(x => x.TechnicianId).NotEmpty().WithMessage(localizationService.GetResource("Technician.Required"));
            RuleFor(x => x.CraftId).NotEmpty().WithMessage(localizationService.GetResource("Craft.Required"));
        }
    }
}