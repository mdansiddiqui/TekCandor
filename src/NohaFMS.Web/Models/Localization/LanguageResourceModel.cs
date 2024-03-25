/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Web.Mvc;
using FluentValidation.Attributes;
using NohaFMS.Web.Validators;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(LanguageResourceValidator))]
    public partial class LanguageResourceModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("LanguageResource.Name")]
        [AllowHtml]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("LanguageResource.Value")]
        [AllowHtml]
        public string Value { get; set; }

        public long LanguageId { get; set; }
    }
}