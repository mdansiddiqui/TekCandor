using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System.Web.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    public class BranchModel : BaseEamEntityModel
    {
       
        [Required]
        [BaseEamResourceDisplayName("System.Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$", ErrorMessage = "Please enter a correct name.")] 
        public string Name { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.Code")]
        public string Code { get; set; }
         
        [Required]
        [BaseEamResourceDisplayName("System.NIFTBranchCode")]
        [RegularExpression(@"^[\d]{1,4}$", ErrorMessage = "Branch Code  must be number")]
        public string NIFTBranchCode { get; set; } 
        [Required]
        [BaseEamResourceDisplayName("System.Email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email.")]

        public string Email { get; set; } 
        [Required]
        [BaseEamResourceDisplayName("System.Hub")]
        public long HubId { get; set; }
        public string HubName { get; set; }
        public IEnumerable<SelectListItem> HubList { get; set; }


    }
}