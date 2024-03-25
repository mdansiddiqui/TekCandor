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
    [Validator(typeof(PMMiscCostValidator))]
    public class PMMiscCostModel : BaseEamEntityModel
    {
        public long? PreventiveMaintenanceId { get; set; }

        [BaseEamResourceDisplayName("PMMiscCost.Sequence")]
        [UIHint("Int32Nullable")]
        public int? Sequence { get; set; }

        [BaseEamResourceDisplayName("PMMiscCost.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("PMMiscCost.PlanUnitPrice")]
        [UIHint("DecimalNullable")]
        public decimal? PlanUnitPrice { get; set; }

        [BaseEamResourceDisplayName("PMMiscCost.PlanQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? PlanQuantity { get; set; }

        [BaseEamResourceDisplayName("PMMiscCost.PlanTotal")]
        [UIHint("DecimalNullable")]
        public decimal? PlanTotal { get; set; }

    }
}