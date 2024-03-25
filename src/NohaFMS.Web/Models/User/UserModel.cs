/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(UserValidator))]
    public partial class UserModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("User.Name")]
        [RegularExpression(@"^[a-zA-Z]+(?:['-][a-zA-Z\s*]+)*$", ErrorMessage = "Please enter a correct name.")]

        public string Name { get; set; }

        [BaseEamResourceDisplayName("User.LoginName")]
        public string LoginName { get; set; }
        [Required]
        [BaseEamResourceDisplayName("User.LoginPassword")]
        [RegularExpression("^((?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])|(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[^a-zA-Z0-9])|(?=.*?[A-Z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])|(?=.*?[a-z])(?=.*?[0-9])(?=.*?[^a-zA-Z0-9])).{8,}$", ErrorMessage = "Passwords must be at least 8 characters and contain at 3 of 4 of the following: upper case (A-Z), lower case (a-z), number (0-9) and special character (e.g. !@#$%^&*)")]
        [DataType(DataType.Password)]
        public string LoginPassword { get; set; }

        [BaseEamResourceDisplayName("User.LoginResetPassword")]
        public string LoginResetPassword { get; set; }

        [BaseEamResourceDisplayName("User.AddressCountry")]
        public string AddressCountry { get; set; }

        [BaseEamResourceDisplayName("User.AddressState")]
        public string AddressState { get; set; }

        [BaseEamResourceDisplayName("User.AddressCity")]
        public string AddressCity { get; set; }

        [BaseEamResourceDisplayName("User.Address")]
        public string Address { get; set; }
    
        [BaseEamResourceDisplayName("User.Phone")]
        [RegularExpression(@"^[\d]{4}-[\d]{7}$", ErrorMessage = "Invalid Phone Number.")]

        public string Phone { get; set; }

        [BaseEamResourceDisplayName("User.Cellphone")]
        public string Cellphone { get; set; }

        [BaseEamResourceDisplayName("User.Email")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z", ErrorMessage = "Please enter a valid email.")]

        public string Email { get; set; }

        [BaseEamResourceDisplayName("User.Fax")]
        public string Fax { get; set; }

        [BaseEamResourceDisplayName("User.Active")]
        public bool Active { get; set; }

        [BaseEamResourceDisplayName("User.UserType")]
        public UserType UserType { get; set; }

        [BaseEamResourceDisplayName("User.DefaultSite")]
        public long? DefaultSiteId { get; set; }

        [BaseEamResourceDisplayName("User.TimeZone")]
        public string TimeZoneId { get; set; }

        [BaseEamResourceDisplayName("User.HubName")]
        public long Hubid { get; set; }
        [BaseEamResourceDisplayName("User.HubName")]
        public string Hubids { get; set; }
        [BaseEamResourceDisplayName("User.HubName")]
        public string[] BranchIdsArray { get; set; }
        public string BranchIds { get; set; }
        [BaseEamResourceDisplayName("User.HubName")]
        public string[] HubidsArray { get; set; }

        [BaseEamResourceDisplayName("User.BrandName")]
        public long BranchId { get; set; }

        public IEnumerable<SelectListItem> HubList { get; set; }

        public IEnumerable<SelectListItem> BranchList { get; set; }


        [BaseEamResourceDisplayName("User.Language")]
        public long? LanguageId { get; set; }

        [BaseEamResourceDisplayName("User.Supervisor")]
        public bool IsSupervisor { get; set; }

        [BaseEamResourceDisplayName("User.WebApiEnabled")]
        public bool WebApiEnabled { get; set; }

        [BaseEamResourceDisplayName("User.PublicKey")]
        public string PublicKey { get; set; }

        [BaseEamResourceDisplayName("User.SecretKey")]
        public string SecretKey { get; set; }

        [BaseEamResourceDisplayName("User.POApprovalLimit")]
        [UIHint("DecimalNullable")]
        public decimal? POApprovalLimit { get; set; }
    }
}