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
    public class ServiceRequestValidator : BaseEamValidator<ServiceRequestModel>
    {
        public ServiceRequestValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("Site.Required"));
            RuleFor(x => x.RequestorName).NotEmpty().WithMessage(localizationService.GetResource("ServiceRequest.RequestorName.Required"));
            RuleFor(x => x.RequestorPhone).NotEmpty().WithMessage(localizationService.GetResource("ServiceRequest.RequestorPhone.Required"));
            RuleFor(x => x.RequestorEmail).NotEmpty().WithMessage(localizationService.GetResource("ServiceRequest.RequestorEmail.Required"));
        }
    }
}