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
    public class AssetSparePartValidator : BaseEamValidator<AssetSparePartModel>
    {
        public AssetSparePartValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ItemId).NotEmpty().WithMessage(localizationService.GetResource("Item.Required"));
            RuleFor(x => x.Quantity).NotEmpty().WithMessage(localizationService.GetResource("AssetSparePart.Quantity.Required"));
        }
    }
}