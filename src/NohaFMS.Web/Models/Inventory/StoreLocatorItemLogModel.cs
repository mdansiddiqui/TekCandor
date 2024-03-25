﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System;

namespace NohaFMS.Web.Models
{
    public class StoreLocatorItemLogModel : BaseEamEntityModel
    {
        public long? StoreLocatorItemId { get; set; }

        public long? StoreId { get; set; }

        [BaseEamResourceDisplayName("StoreLocator")]
        public long? StoreLocatorId { get; set; }
        public StoreLocatorModel StoreLocator { get; set; }

        [BaseEamResourceDisplayName("Item")]
        public long? ItemId { get; set; }
        public ItemModel Item { get; set; }

        public DateTime? BatchDate { get; set; }

        public decimal? UnitPrice { get; set; }

        [BaseEamResourceDisplayName("StoreLocatorItemLog.QuantityChanged")]
        public decimal? QuantityChanged { get; set; }

        [BaseEamResourceDisplayName("StoreLocatorItemLog.CostChanged")]
        public decimal? CostChanged { get; set; }

        //Transaction Details
        [BaseEamResourceDisplayName("StoreLocatorItemLog.TransactionType")]
        public string TransactionType { get; set; }

        public long? TransactionId { get; set; }

        [BaseEamResourceDisplayName("StoreLocatorItemLog.TransactionNumber")]
        public string TransactionNumber { get; set; }

        [BaseEamResourceDisplayName("StoreLocatorItemLog.TransactionDate")]
        public DateTime? TransactionDate { get; set; }

        public long? TransactionItemId { get; set; }
    }
}