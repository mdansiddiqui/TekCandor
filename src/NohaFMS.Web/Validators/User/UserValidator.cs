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
    public partial class UserValidator : BaseEamValidator<UserModel>
    {
        public UserValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("User.Name.Required"));
            RuleFor(x => x.Email).NotEmpty().WithMessage(localizationService.GetResource("User.Email.Required"));
            RuleFor(x => x.LoginName).NotEmpty().WithMessage(localizationService.GetResource("User.LoginName.Required"));
        }
    }
}