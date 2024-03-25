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
    [Validator(typeof(ReturnValidator))]
    public class ReturnModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Return.Number")]
        public string Number { get; set; }

        [BaseEamResourceDisplayName("Return.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Return.ReturnDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? ReturnDate { get; set; }

        [BaseEamResourceDisplayName("Site")]
        public long? SiteId { get; set; }
        public SiteModel Site { get; set; }

        [BaseEamResourceDisplayName("Store")]
        public long? StoreId { get; set; }
        public StoreModel Store { get; set; }

        [BaseEamResourceDisplayName("Return.IsApproved")]
        public bool IsApproved { get; set; }
    }
}