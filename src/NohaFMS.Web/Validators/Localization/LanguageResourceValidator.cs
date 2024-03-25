/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using FluentValidation;
using NohaFMS.Web.Models;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;

namespace NohaFMS.Web.Validators
{
    public partial class LanguageResourceValidator : BaseEamValidator<LanguageResourceModel>
    {
        public LanguageResourceValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("LanguageResource.Name.Required"));
            RuleFor(x => x.Value).NotEmpty().WithMessage(localizationService.GetResource("LanguageResource.Value.Required"));
        }
    }
}