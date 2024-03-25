/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Configuration;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Core.Domain
{
    public class InventorySettings : ISettings
    {
        public int? CostingType { get; set; }
    }

    public enum ItemCostingType
    {
        [Description("ItemCostingType.FIFO.Hint")]
        [Display(Name = "ItemCostingType.FIFO")]
        FIFO = 0,

        [Description("ItemCostingType.LIFO.Hint")]
        [Display(Name = "ItemCostingType.LIFO")]
        LIFO,

        [Description("ItemCostingType.StandardCosting.Hint")]
        [Display(Name = "ItemCostingType.StandardCosting")]
        StandardCosting,

        [Description("ItemCostingType.AverageCosting.Hint")]
        [Display(Name = "ItemCostingType.AverageCosting")]
        AverageCosting
    }

    public enum ItemStockType
    {
        Stock = 0,
        NonStock,
        Other
    }

    public enum ItemCategory
    {
        Part,
        Tool,
        Asset,
        Other
    }

    public enum ItemLotType
    {
        NoLot,
        Lot
    }
}
