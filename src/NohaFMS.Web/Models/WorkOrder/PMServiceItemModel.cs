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
    [Validator(typeof(PMServiceItemValidator))]
    public class PMServiceItemModel : BaseEamEntityModel
    {
        public long? PreventiveMaintenanceId { get; set; }

        [BaseEamResourceDisplayName("ServiceItem")]
        public long? ServiceItemId { get; set; }
        public string ServiceItemName { get; set; }

        [BaseEamResourceDisplayName("PMServiceItem.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("PMServiceItem.PlanUnitPrice")]
        [UIHint("DecimalNullable")]
        public decimal? PlanUnitPrice { get; set; }

        [BaseEamResourceDisplayName("PMServiceItem.PlanQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? PlanQuantity { get; set; }

        [BaseEamResourceDisplayName("PMServiceItem.PlanTotal")]
        [UIHint("DecimalNullable")]
        public decimal? PlanTotal { get; set; }

    }
}