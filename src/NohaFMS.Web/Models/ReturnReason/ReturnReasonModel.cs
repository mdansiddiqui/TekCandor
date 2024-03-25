using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    public class ReturnReasonModel : BaseEamEntityModel

    {
        [Required]
        [BaseEamResourceDisplayName("System.Name")]
        public string Name { get; set; }
        public string Code { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.AlphaReturnCodes")]
        public string AlphaReturnCodes { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.NumericReturnCodes")]
        public int NumericReturnCodes { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.Status")]
        public string Status { get; set; }
        
        [BaseEamResourceDisplayName("System.DescriptionWithReturnCodes")]

        public string DescriptionWithReturnCodes { get; set; }





    }
}