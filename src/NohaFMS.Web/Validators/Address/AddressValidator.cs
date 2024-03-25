/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;

namespace NohaFMS.Web.Validators
{
    public class AddressValidator : BaseEamValidator<AddressModel>
    {
        public AddressValidator(ILocalizationService localizationService)
        {
            //RuleFor(x => x.Address1).NotEmpty().WithMessage(localizationService.GetResource("Address.Address1.Required"));
            //RuleFor(x => x.PhoneNumber).NotEmpty().WithMessage(localizationService.GetResource("Address.PhoneNumber.Required"));
            //RuleFor(x => x.Email).EmailAddress().WithMessage(localizationService.GetResource("Address.Email.Invalid"));
        }
    }
}