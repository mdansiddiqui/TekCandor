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
    [Validator(typeof(FeatureActionValidator))]
    public class FeatureActionModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Feature.Name")]
        public long? FeatureId { get; set; }

        [BaseEamResourceDisplayName("FeatureAction.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("FeatureAction.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Common.DisplayOrder")]
        public int DisplayOrder { get; set; }
    }
}