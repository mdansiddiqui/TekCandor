/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ReportValidator))]
    public class ReportModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Report.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Report.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Report.Type")]
        public string Type { get; set; }

        [BaseEamResourceDisplayName("Report.TemplateType")]
        public ReportTemplateType TemplateType { get; set; }
        public string TemplateTypeText { get; set; }

        [BaseEamResourceDisplayName("Report.TemplateFileName")]
        public string TemplateFileName { get; set; }

        [BaseEamResourceDisplayName("Report.TemplateFileBytes")]
        public byte[] TemplateFileBytes { get; set; }

        [BaseEamResourceDisplayName("Report.Query")]
        public string Query { get; set; }

        [BaseEamResourceDisplayName("Report.SortExpression")]
        public string SortExpression { get; set; }

        [BaseEamResourceDisplayName("Report.IncludeCurrentUserInQuery")]
        public bool IncludeCurrentUserInQuery { get; set; }

        [BaseEamResourceDisplayName("Common.UploadFile")]
        public long? UploadFileId { get; set; }
        public object VisualTypeText { get; internal set; }
        public object VisualType { get; internal set; }
    }
}