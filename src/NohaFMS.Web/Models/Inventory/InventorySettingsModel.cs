/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;

namespace NohaFMS.Web.Models
{
    public class InventorySettingsModel : BaseEamModel
    {
        [BaseEamResourceDisplayName("InventorySettings.CostingType")]
        public ItemCostingType CostingType { get; set; }
    }
}