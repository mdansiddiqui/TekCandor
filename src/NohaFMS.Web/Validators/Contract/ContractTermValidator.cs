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
    public class ContractTermValidator : BaseEamValidator<ContractTermModel>
    {
        public ContractTermValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Sequence).NotEmpty().WithMessage(localizationService.GetResource("Common.Sequence.Required"));
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Common.Name.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("Common.Description.Required"));
        }
    }
}