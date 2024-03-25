﻿using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    public class ReadingModel : BaseEamEntityModel
    {
        public long? PointMeterLineItemId { get; set; }

        [BaseEamResourceDisplayName("Meter")]
        public string PointMeterLineItemMeterName { get; set; }

        [BaseEamResourceDisplayName("Reading.ReadingValue")]
        [UIHint("DecimalNullable")]
        public decimal? ReadingValue { get; set; }

        [BaseEamResourceDisplayName("Reading.DateOfReading")]
        [UIHint("DateTimeNullable")]
        public DateTime? DateOfReading { get; set; }

        [BaseEamResourceDisplayName("Reading.ReadingSource")]
        public ReadingSource ReadingSource { get; set; }
        public string ReadingSourceText { get; set; }
    }
}