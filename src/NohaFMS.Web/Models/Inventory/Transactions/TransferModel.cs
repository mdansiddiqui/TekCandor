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
    [Validator(typeof(TransferValidator))]
    public class TransferModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Transfer.Number")]
        public string Number { get; set; }

        [BaseEamResourceDisplayName("Transfer.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Transfer.TransferDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? TransferDate { get; set; }

        [BaseEamResourceDisplayName("Transfer.FromSite")]
        public long? FromSiteId { get; set; }
        public SiteModel FromSite { get; set; }

        [BaseEamResourceDisplayName("Transfer.FromStore")]
        public long? FromStoreId { get; set; }
        public StoreModel FromStore { get; set; }

        [BaseEamResourceDisplayName("Transfer.ToSite")]
        public long? ToSiteId { get; set; }
        public SiteModel ToSite { get; set; }

        [BaseEamResourceDisplayName("Transfer.ToStore")]
        public long? ToStoreId { get; set; }
        public StoreModel ToStore { get; set; }

        public bool IsApproved { get; set; }

    }
}