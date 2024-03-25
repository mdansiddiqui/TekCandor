/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ReportFilterValidator))]
    public class ReportFilterModel : BaseEamEntityModel
    {
        public long? ReportId { get; set; }

        [BaseEamResourceDisplayName("Common.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Filter")]
        public long? FilterId { get; set; }
        public string FilterName { get; set; }

        [BaseEamResourceDisplayName("ParentReportFilter")]
        public long? ParentReportFilterId { get; set; }
        public string ParentReportFilterFilterName { get; set; }

        [BaseEamResourceDisplayName("Common.DisplayOrder")]
        [UIHint("Int32Nullable")]
        public int? DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("ReportFilter.DbColumn")]
        public string DbColumn { get; set; }

        [BaseEamResourceDisplayName("ReportFilter.ResourceKey")]
        public string ResourceKey { get; set; }

        [BaseEamResourceDisplayName("ReportFilter.IsRequired")]
        public bool IsRequired { get; set; }

    }
}