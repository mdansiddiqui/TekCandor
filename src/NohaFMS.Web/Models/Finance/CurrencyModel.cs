/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(CurrencyValidator))]
    public class CurrencyModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Currency.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Currency.CurrencyCode")]
        public string CurrencyCode { get; set; }

        [BaseEamResourceDisplayName("Currency.DisplayLocale")]
        public string DisplayLocale { get; set; }

        [BaseEamResourceDisplayName("Currency.Rate")]
        public decimal Rate { get; set; }

        [BaseEamResourceDisplayName("Currency.CustomFormatting")]
        public string CustomFormatting { get; set; }

        [BaseEamResourceDisplayName("Currency.Published")]
        public bool Published { get; set; }

        [BaseEamResourceDisplayName("Common.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("Currency.IsPrimaryExchangeRateCurrency")]
        public bool IsPrimaryExchangeRateCurrency { get; set; }

        [BaseEamResourceDisplayName("Currency.IsPrimarySystemCurrency")]
        public bool IsPrimarySystemCurrency { get; set; }
    }
}