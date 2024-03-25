/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ReturnItemValidator))]
    [Bind(Exclude = "IssueItem")]
    public class ReturnItemModel
    {
        public long Id { get; set; }

        public long? ReturnId { get; set; }

        [BaseEamResourceDisplayName("IssueItem")]
        public long? IssueItemId { get; set; }
        public IssueItemModel IssueItem { get; set; }

        [BaseEamResourceDisplayName("ReturnItem.ReturnQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? ReturnQuantity { get; set; }

        [BaseEamResourceDisplayName("ReturnItem.ReturnCost")]
        [UIHint("DecimalNullable")]
        public decimal? ReturnCost { get; set; }

    }
}