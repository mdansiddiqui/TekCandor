using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    public class HubModel : BaseEamEntityModel
    {
        [Required]
        [BaseEamResourceDisplayName("System.Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$", ErrorMessage = "Please enter a correct name.")]

        public string Name { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.Code")]
        public string Code { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.City")]
        public long CityId { get; set; }

        public IEnumerable<SelectListItem> CityList { get; set; }

    }
}