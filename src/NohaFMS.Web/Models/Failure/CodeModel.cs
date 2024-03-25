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
    [Validator(typeof(CodeValidator))]
    public class CodeModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Code.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Code.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Code.Parent")]
        public long? ParentId { get; set; }

        [BaseEamResourceDisplayName("Code.Parent")]
        public string ParentName { get; set; }

        public string HierarchyIdPath { get; set; }

        [BaseEamResourceDisplayName("Common.HierarchyNamePath")]
        public string HierarchyNamePath { get; set; }

        [BaseEamResourceDisplayName("Code.CodeType")]
        public string CodeType { get; set; }
    }
}