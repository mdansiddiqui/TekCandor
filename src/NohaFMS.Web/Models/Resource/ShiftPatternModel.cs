using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ShiftPatternValidator))]
    public class ShiftPatternModel : BaseEamEntityModel
    {

        public long? ShiftId { get; set; }

        [BaseEamResourceDisplayName("ShiftPattern.Sequence")]
        public int? Sequence { get; set; }

        [BaseEamResourceDisplayName("ShiftPattern.StartTime")]
        public DateTime? StartTime { get; set; }

        [BaseEamResourceDisplayName("ShiftPattern.EndTime")]
        public DateTime? EndTime { get; set; }
    }
}