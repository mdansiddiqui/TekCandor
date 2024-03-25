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
    [Validator(typeof(SiteValidator))]
    public class SiteModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Site.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Site.Description")]
        public string Description { get; set; }
    }
}