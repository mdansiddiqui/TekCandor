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
    [Validator(typeof(FeatureValidator))]
    public class FeatureModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Feature.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Feature.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Common.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("Feature.WorkflowEnabled")]
        public bool WorkflowEnabled { get; set; }

        [BaseEamResourceDisplayName("Module.Name")]
        public long? ModuleId { get; set; }
    }
}