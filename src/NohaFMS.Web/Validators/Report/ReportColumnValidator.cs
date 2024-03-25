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
    public class ReportColumnValidator : BaseEamValidator<ReportColumnModel>
    {
        public ReportColumnValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.ColumnName).NotEmpty().WithMessage(localizationService.GetResource("ReportColumn.ColumnName.Required"));
            RuleFor(x => x.ResourceKey).NotEmpty().WithMessage(localizationService.GetResource("ReportColumn.ResourceKey.Required"));
        }

    }
}