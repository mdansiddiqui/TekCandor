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
    public class TransferValidator : BaseEamValidator<TransferModel>
    {
        public TransferValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.TransferDate).NotEmpty().WithMessage(localizationService.GetResource("Transfer.TransferDate.Required"));
            RuleFor(x => x.FromSiteId).NotEmpty().WithMessage(localizationService.GetResource("Transfer.FromSite.Required"));
            RuleFor(x => x.FromStoreId).NotEmpty().WithMessage(localizationService.GetResource("Transfer.FromStore.Required"));
            RuleFor(x => x.ToSiteId).NotEmpty().WithMessage(localizationService.GetResource("Transfer.ToSite.Required"));
            RuleFor(x => x.ToStoreId).NotEmpty().WithMessage(localizationService.GetResource("Transfer.ToStore.Required"));
        }
    }
}