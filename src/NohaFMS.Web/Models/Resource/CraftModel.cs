using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(CraftValidator))]
    public class CraftModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Craft.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Craft.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Craft.StandardRate")]
        [UIHint("DecimalNullable")]
        public decimal? StandardRate { get; set; }

        [BaseEamResourceDisplayName("Craft.OvertimeRate")]
        [UIHint("DecimalNullable")]
        public decimal? OvertimeRate { get; set; }

    }
}