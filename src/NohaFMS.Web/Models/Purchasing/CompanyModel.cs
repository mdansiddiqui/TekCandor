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
    [Validator(typeof(CompanyValidator))]
    public class CompanyModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Company.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Company.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Company.Website")]
        public string Website { get; set; }

        [BaseEamResourceDisplayName("Company.CompanyType")]
        public long? CompanyTypeId { get; set; }
        public ValueItemModel CompanyType { get; set; }

        [BaseEamResourceDisplayName("Company.Currency")]
        public long? CurrencyId { get; set; }
        public CurrencyModel Currency { get; set; }

    }
}