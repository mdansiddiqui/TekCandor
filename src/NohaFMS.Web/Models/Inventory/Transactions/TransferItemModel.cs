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
    [Validator(typeof(TransferItemValidator))]
    public class TransferItemModel : BaseEamEntityModel
    {
        //Cache StoreId from Transfer
        public long? FromStoreId { get; set; }
        public long? ToStoreId { get; set; }

        [BaseEamResourceDisplayName("TransferItem.Transfer")]
        public long? TransferId { get; set; }

        [BaseEamResourceDisplayName("TransferItem.FromStoreLocator")]
        public long? FromStoreLocatorId { get; set; }
        public StoreLocatorModel FromStoreLocator { get; set; }

        [BaseEamResourceDisplayName("TransferItem.ToStoreLocator")]
        public long? ToStoreLocatorId { get; set; }
        public StoreLocatorModel ToStoreLocator { get; set; }

        [BaseEamResourceDisplayName("TransferItem.Item")]
        public long? ItemId { get; set; }
        public string ItemName { get; set; }
        [BaseEamResourceDisplayName("UnitOfMeasure")]
        public long? ItemUnitOfMeasureId { get; set; }
        public string ItemUnitOfMeasureName { get; set; }

        [BaseEamResourceDisplayName("TransferItem.TransferQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? TransferQuantity { get; set; }

        [BaseEamResourceDisplayName("UnitOfMeasure")]
        public long? TransferUnitOfMeasureId { get; set; }
        public string TransferUnitOfMeasureName { get; set; }

        [BaseEamResourceDisplayName("TransferItem.TransferCost")]
        [UIHint("DecimalNullable")]
        public decimal? TransferCost { get; set; }

        [BaseEamResourceDisplayName("TransferItem.CurrentQuantity")]
        [UIHint("DecimalNullable")]
        public decimal CurrentQuantity { get; set; }
    }
}