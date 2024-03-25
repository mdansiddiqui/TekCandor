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
    [Validator(typeof(PMMeterFrequencyValidator))]
    public class PMMeterFrequencyModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("PreventiveMaintenance")]
        public long? PreventiveMaintenanceId { get; set; }

        [BaseEamResourceDisplayName("PMMeterFrequency.Frequency")]
        [UIHint("DecimalNullable")]
        public decimal? Frequency { get; set; }

        [BaseEamResourceDisplayName("PMMeterFrequency.EndReading")]
        [UIHint("DecimalNullable")]
        public decimal? EndReading { get; set; }

        [BaseEamResourceDisplayName("PMMeterFrequency.GeneratedReading")]
        [UIHint("DecimalNullable")]
        public decimal? GeneratedReading { get; set; }

        [BaseEamResourceDisplayName("Meter")]
        public long? MeterId { get; set; }
        public string MeterName { get; set; }

        [BaseEamResourceDisplayName("UnitOfMeasure")]
        public string MeterUnitOfMeasureName { get; set; }
    }
}