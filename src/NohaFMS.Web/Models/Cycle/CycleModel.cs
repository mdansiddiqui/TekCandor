
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    // [Validator(typeof(AttributeValidator))]
    public class CycleModel : BaseEamEntityModel
    {
        [Required]
        [BaseEamResourceDisplayName("System.Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$", ErrorMessage = "Please enter a correct name.")]

        public string Name { get; set; }
        [Required]

        [BaseEamResourceDisplayName("System.CycleCode")]
        // [RegularExpression(@"^[\d]{1,4}$", ErrorMessage = "
        // must be in a number")]
        [RegularExpression(@"^[\d]{1,4}$", ErrorMessage = "Cycle Code  must be number")]
        public string Code { get; set; }
        [Required]

        [BaseEamResourceDisplayName("System.description")]
       // [RegularExpression(@"^[\d]{1,4}$", ErrorMessage = "
       // must be in a number")]
        public string Description { get; set; }

    }
}