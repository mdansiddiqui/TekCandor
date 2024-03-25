using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
   // [Validator(typeof(AttributeValidator))]
    public class CityModel : BaseEamEntityModel
    {
        [Required]
        [BaseEamResourceDisplayName("System.Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$", ErrorMessage = "Please enter a correct name.")]

        public string Name { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.CityCode")]
        [RegularExpression(@"^[\d]{1,4}$", ErrorMessage = "City Code  must be number")]
        public string Code { get; set; }

    }
}