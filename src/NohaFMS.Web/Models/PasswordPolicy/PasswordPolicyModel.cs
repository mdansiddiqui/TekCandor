using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    public class PasswordPolicyModel : BaseEamEntityModel
    {
        [Required]
        [BaseEamResourceDisplayName("System.PolicyName")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("System.PolicyCode")]
        public string Code { get; set; }
        [Required]
        [BaseEamResourceDisplayName("System.PolicyNameOther")]
        public string NameOther { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyDescription")]
        public string Description { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyCountHistory")]
        public int CountHistory { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyExpiryDays")]
        public int ExpiryDays { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyNotifyDays")]
        public int NotifyDays { get; set; }
        
        [BaseEamResourceDisplayName("System.DisableDays")]
        public int AccountDisableDays { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyInvalidLoginEntry")]
        public int InvalidLoginEntry { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyFirstReset")]
        public bool FirstReset { get; set; }
        
        [BaseEamResourceDisplayName("System.PolicyCyclicPassword")]
        public bool CyclicPassword { get; set; }
        
    }
}