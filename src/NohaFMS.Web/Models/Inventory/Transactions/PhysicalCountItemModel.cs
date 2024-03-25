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
    [Validator(typeof(PhysicalCountItemValidator))]
    public class PhysicalCountItemModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("PhysicalCount")]
        public long? PhysicalCountId { get; set; }

        [BaseEamResourceDisplayName("StoreLocatorItemBalance")]
        public long? StoreLocatorItemId { get; set; }
        public StoreLocatorItemBalance StoreLocatorItemBalance { get; set; }

        [BaseEamResourceDisplayName("Item")]
        public long? ItemId { get; set; }
        public string ItemName { get; set; }
        [BaseEamResourceDisplayName("UnitOfMeasure")]
        public long? ItemUnitOfMeasureId { get; set; }
        public string ItemUnitOfMeasureName { get; set; }

        [BaseEamResourceDisplayName("StoreLocator")]
        public long? StoreLocatorId { get; set; }
        public string StoreLocatorName { get; set; }

        [BaseEamResourceDisplayName("PhysicalCountItem.Count")]
        [UIHint("DecimalNullable")]
        public decimal? Count { get; set; }

        [BaseEamResourceDisplayName("PhysicalCountItem.CurrentQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? CurrentQuantity { get; set; }
    }
}