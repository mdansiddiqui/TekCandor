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
    public partial class AssignmentGroupUserValidator : BaseEamValidator<AssignmentGroupUserModel>
    {
        public AssignmentGroupUserValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("AssignmentGroupUser.Site.Required"));
            RuleFor(x => x.UserId).NotEmpty().WithMessage(localizationService.GetResource("AssignmentGroupUser.User.Required"));
        }
    }
}