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
    [Validator(typeof(ReportColumnValidator))]
    public class ReportColumnModel : BaseEamEntityModel
    {
        public long? ReportId { get; set; }

        [BaseEamResourceDisplayName("Common.DisplayOrder")]
        [UIHint("Int32Nullable")]
        public int? DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("ReportColumn.ColumnName")]
        public string ColumnName { get; set; }

        [BaseEamResourceDisplayName("ReportColumn.DataType")]
        public string DataType { get; set; }

        [BaseEamResourceDisplayName("ReportColumn.FormatString")]
        public string FormatString { get; set; }

        [BaseEamResourceDisplayName("ReportColumn.ResourceKey")]
        public string ResourceKey { get; set; }

    }
}