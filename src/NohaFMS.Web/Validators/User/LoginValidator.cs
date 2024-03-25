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
    public class LoginValidator : BaseEamValidator<LoginModel>
    {
        public LoginValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.LoginName).NotEmpty().WithMessage(localizationService.GetResource("User.LoginName.Required"));
            RuleFor(x => x.LoginPassword).NotEmpty().WithMessage(localizationService.GetResource("User.LoginPassword.Required"));
        }
    }
}