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
    [Validator(typeof(AssetSparePartValidator))]
    public class AssetSparePartModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Asset")]
        public long? AssetId { get; set; }
        public AssetModel Asset { get; set; }

        [BaseEamResourceDisplayName("Item")]
        public long? ItemId { get; set; }
        public string ItemName { get; set; }

        [BaseEamResourceDisplayName("AssetSparePart.Quantity")]
        [UIHint("DecimalNullable")]
        public decimal? Quantity { get; set; }
    }
}