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
    [Validator(typeof(AuditEntityConfigurationValidator))]
    public class AuditEntityConfigurationModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("AuditEntityConfiguration.ExcludedColumn")]
        public string ExcludedColumn { get; set; }

        [BaseEamResourceDisplayName("AuditEntityConfiguration.ExcludedColumns")]
        public string ExcludedColumns { get; set; }
    }
}