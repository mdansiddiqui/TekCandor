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

    public class MeterEventValidator : BaseEamValidator<MeterEventModel>
    {
        public MeterEventValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("MeterEvent.Description.Required"));
            RuleFor(x => x).Must(UpperOrLowerLimitRequired).WithMessage(localizationService.GetResource("MeterEvent.UpperOrLowerLimit.Required"));
        }

        private bool UpperOrLowerLimitRequired(MeterEventModel model)
        {
            return model.UpperLimit != null || model.LowerLimit != null;
        }
    }
}