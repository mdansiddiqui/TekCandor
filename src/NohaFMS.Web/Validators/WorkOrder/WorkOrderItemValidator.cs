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
    public class WorkOrderItemValidator : BaseEamValidator<WorkOrderItemModel>
    {
        public WorkOrderItemValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.StoreId).NotEmpty().WithMessage(localizationService.GetResource("Store.Required"));
            RuleFor(x => x.ItemId).NotEmpty().WithMessage(localizationService.GetResource("Item.Required"));
            RuleFor(x => x.StoreLocatorId).NotEmpty().WithMessage(localizationService.GetResource("StoreLocator.Required"));
        }
    }
}