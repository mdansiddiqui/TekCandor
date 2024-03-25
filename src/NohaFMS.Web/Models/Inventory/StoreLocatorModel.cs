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
    [Validator(typeof(StoreLocatorValidator))]
    public class StoreLocatorModel : BaseEamEntityModel
    {
        public long? StoreId { get; set; }

        [BaseEamResourceDisplayName("StoreLocator.Name")]
        public string Name { get; set; }

        public bool IsDefault { get; set; }
    }
}