/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;

namespace NohaFMS.Web.Models
{
    public partial class UserSearchModel : BaseEamModel
    {
        [BaseEamResourceDisplayName("User.Search.Name")]
        public string Name { get; set; }
    }
}