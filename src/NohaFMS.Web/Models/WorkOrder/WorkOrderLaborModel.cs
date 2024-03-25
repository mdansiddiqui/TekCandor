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
    [Validator(typeof(WorkOrderLaborValidator))]
    public class WorkOrderLaborModel : BaseEamEntityModel
    {
        public long? WorkOrderId { get; set; }

        [BaseEamResourceDisplayName("WorkOrder")]
        public string WorkOrderNumber { get; set; }

        [BaseEamResourceDisplayName("Team")]
        public long? TeamId { get; set; }
        public string TeamName { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.TechnicianMatching")]
        public TechnicianMatching TechnicianMatching { get; set; }

        [BaseEamResourceDisplayName("Technician")]
        public long? TechnicianId { get; set; }
        public string TechnicianName { get; set; }

        [BaseEamResourceDisplayName("Craft")]
        public long? CraftId { get; set; }
        public string CraftName { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.PlanHours")]
        [UIHint("DecimalNullable")]
        public decimal? PlanHours { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.StandardRate")]
        [UIHint("DecimalNullable")]
        public decimal? StandardRate { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.OTRate")]
        [UIHint("DecimalNullable")]
        public decimal? OTRate { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.PlanTotal")]
        [UIHint("DecimalNullable")]
        public decimal? PlanTotal { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.ActualNormalHours")]
        [UIHint("DecimalNullable")]
        public decimal? ActualNormalHours { get; set; }

        [BaseEamResourceDisplayName("WorkOrderLabor.ActualOTHours")]
        [UIHint("DecimalNullable")]
        public decimal? ActualOTHours { get; set; }        

        [BaseEamResourceDisplayName("WorkOrderLabor.ActualTotal")]
        [UIHint("DecimalNullable")]
        public decimal? ActualTotal { get; set; }
    }
}