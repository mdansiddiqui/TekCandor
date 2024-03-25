/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System;
using System.Globalization;

namespace NohaFMS.Web.Validators
{
    public class CurrencyValidator : BaseEamValidator<CurrencyModel>
    {
        public CurrencyValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Currency.Name.Required"));
            RuleFor(x => x.CurrencyCode).NotEmpty().WithMessage(localizationService.GetResource("Currency.CurrencyCode.Required"));
            RuleFor(x => x.Rate).GreaterThan(0).WithMessage(localizationService.GetResource("Currency.Rate.Range"));
            RuleFor(x => x.DisplayLocale)
                .Must(x =>
                {
                    try
                    {
                        if (String.IsNullOrEmpty(x))
                            return true;
                        //let's try to create a CultureInfo object
                        //if "DisplayLocale" is wrong, then exception will be thrown
                        var culture = new CultureInfo(x);
                        return true;
                    }
                    catch
                    {
                        return false;
                    }
                })
                .WithMessage(localizationService.GetResource("Currency.DisplayLocale.Invalid"));
        }
    }
}