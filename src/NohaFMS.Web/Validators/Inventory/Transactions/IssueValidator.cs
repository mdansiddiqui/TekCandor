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
    public class IssueValidator : BaseEamValidator<IssueModel>
    {
        public IssueValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("Site.Required"));
            RuleFor(x => x.StoreId).NotEmpty().WithMessage(localizationService.GetResource("Store.Required"));
            RuleFor(x => x.IssueDate).NotEmpty().WithMessage(localizationService.GetResource("Issue.IssueDate.Required"));
        }
    }
}