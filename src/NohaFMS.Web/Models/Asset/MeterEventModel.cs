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
    [Validator(typeof(MeterEventValidator))]
    public class MeterEventModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("MeterEvent.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("MeterEvent.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [BaseEamResourceDisplayName("Point")]
        public long? PointId { get; set; }
        
        public long? MeterId { get; set; }
        [BaseEamResourceDisplayName("Meter")]
        public string MeterName { get; set; }

        [BaseEamResourceDisplayName("MeterEvent.UpperLimit")]
        [UIHint("DecimalNullable")]
        public decimal? UpperLimit { get; set; }

        [BaseEamResourceDisplayName("MeterEvent.LowerLimit")]
        [UIHint("DecimalNullable")]
        public decimal? LowerLimit { get; set; }
    }
}