/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(AdjustValidator))]
    public class AdjustModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Adjust.Number")]
        public string Number { get; set; }

        [BaseEamResourceDisplayName("Adjust.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Adjust.AdjustDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? AdjustDate { get; set; }

        [BaseEamResourceDisplayName("Adjust.Site")]
        public long? SiteId { get; set; }
        public SiteModel Site { get; set; }

        [BaseEamResourceDisplayName("Adjust.Store")]
        public long? StoreId { get; set; }
        public StoreModel Store { get; set; }

        [BaseEamResourceDisplayName("Adjust.IsApproved")]
        public bool IsApproved { get; set; }
    }
}