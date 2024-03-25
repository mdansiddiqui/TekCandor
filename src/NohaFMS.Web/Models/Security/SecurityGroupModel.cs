/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(SecurityGroupValidator))]
    
    public class SecurityGroupModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("SecurityGroup.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("SecurityGroup.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("SecurityGroup.LowerLimit")]
        public int LowerLimit { get; set; }

        [BaseEamResourceDisplayName("SecurityGroup.UpperLimit")]
        public int UpperLimit { get; set; }
        [Required]
        public string LimitGroup { get; set; }
    }
}