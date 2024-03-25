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
    [Validator(typeof(WorkOrderMiscCostValidator))]
    public class WorkOrderMiscCostModel : BaseEamEntityModel
    {
        public long? WorkOrderId { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.Sequence")]
        [UIHint("Int32Nullable")]
        public int? Sequence { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.PlanUnitPrice")]
        [UIHint("DecimalNullable")]
        public decimal? PlanUnitPrice { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.PlanQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? PlanQuantity { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.PlanTotal")]
        [UIHint("DecimalNullable")]
        public decimal? PlanTotal { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.ActualUnitPrice")]
        [UIHint("DecimalNullable")]
        public decimal? ActualUnitPrice { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.ActualQuantity")]
        [UIHint("DecimalNullable")]
        public decimal? ActualQuantity { get; set; }

        [BaseEamResourceDisplayName("WorkOrderMiscCost.ActualTotal")]
        [UIHint("DecimalNullable")]
        public decimal? ActualTotal { get; set; }
    }
}