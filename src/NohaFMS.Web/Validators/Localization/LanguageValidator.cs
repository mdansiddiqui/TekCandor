/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Globalization;
using FluentValidation;
using NohaFMS.Web.Models;
using NohaFMS.Data;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;

namespace NohaFMS.Web.Validators
{
    public partial class LanguageValidator : BaseEamValidator<LanguageModel>
    {
        public LanguageValidator(ILocalizationService localizationService, IDbContext dbContext)
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Language.Name.Required"));
            RuleFor(x => x.LanguageCulture)
                .Must(x =>
                          {
                              try
                              {
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
                .WithMessage(localizationService.GetResource("Language.LanguageCulture.Validation"));
        }
    }
}