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
    public class PhysicalCountItemValidator : BaseEamValidator<PhysicalCountItemModel>
    {
        public PhysicalCountItemValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Count).NotEmpty().WithMessage(localizationService.GetResource("PhysicalCountItem.Count.Required"));
        }
    }
}