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
    [Validator(typeof(LoginValidator))]
    public partial class LoginModel : BaseEamModel
    {
        [BaseEamResourceDisplayName("User.LoginName")]
        public string LoginName { get; set; }

        [DataType(DataType.Password)]
        [BaseEamResourceDisplayName("User.LoginPassword")]
        public string LoginPassword { get; set; }

    }
}