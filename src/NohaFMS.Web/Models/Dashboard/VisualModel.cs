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
    [Validator(typeof(VisualValidator))]
    public class VisualModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Visual.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Visual.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Visual.VisualType")]
        public VisualType VisualType { get; set; }
        public string VisualTypeText { get; set; }

        [BaseEamResourceDisplayName("Visual.Query")]
        public string Query { get; set; }

        [BaseEamResourceDisplayName("Visual.SortExpression")]
        public string SortExpression { get; set; }

        [BaseEamResourceDisplayName("Visual.XAxis")]
        public string XAxis { get; set; }

        [BaseEamResourceDisplayName("Visual.YAxis")]
        public string YAxis { get; set; }
    }
}