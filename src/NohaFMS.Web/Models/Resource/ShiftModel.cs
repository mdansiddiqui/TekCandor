﻿using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ShiftValidator))]
    public class ShiftModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Shift.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Shift.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Shift.CalendarName")]
        public long? CalendarId { get; set; }
        public CalendarModel Calendar { get; set; }

        [BaseEamResourceDisplayName("Shift.StartDay")]
        public WeekDay StartDay { get; set; }

        [BaseEamResourceDisplayName("Shift.DaysInPattern")]
        [UIHint("Int32Nullable")]
        public int? DaysInPattern { get; set; }

    }
}