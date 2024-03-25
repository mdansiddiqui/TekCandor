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
    public class ContractValidator : BaseEamValidator<ContractModel>
    {
        public ContractValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("Site.Required"));
            RuleFor(x => x.StartDate).NotEmpty().WithMessage(localizationService.GetResource("Contract.StartDate.Required"));
            RuleFor(x => x.EndDate).NotEmpty().WithMessage(localizationService.GetResource("Contract.EndDate.Required"));
            RuleFor(x => x.Total).NotEmpty().WithMessage(localizationService.GetResource("Contract.Total.Required"));
            RuleFor(x => x.VendorId).NotEmpty().WithMessage(localizationService.GetResource("Vendor.Required"));
        }
    }
}