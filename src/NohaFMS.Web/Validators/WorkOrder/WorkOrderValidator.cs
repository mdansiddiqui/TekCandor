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
    public class WorkOrderValidator : BaseEamValidator<WorkOrderModel>
    {
        public WorkOrderValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("Site.Required"));
            RuleFor(x => x.Description).NotEmpty().WithMessage(localizationService.GetResource("WorkOrder.Description.Required"));
            RuleFor(x => x).Must(AssetOrLocationRequired).WithMessage(localizationService.GetResource("WorkOrder.AssetOrLocationRequired"));
        }

        private bool AssetOrLocationRequired(WorkOrderModel model)
        {
            return model.AssetId != null || model.LocationId != null;
        }
    }
}