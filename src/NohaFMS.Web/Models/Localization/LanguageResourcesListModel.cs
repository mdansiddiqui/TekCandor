/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;

namespace NohaFMS.Web.Models
{
    public class LanguageResourcesListModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("LanguageResourcesList.SearchResourceName")]
        public string SearchResourceName { get; set; }
        [BaseEamResourceDisplayName("LanguageResourcesList.SearchResourceValue")]
        public string SearchResourceValue { get; set; }
    }
}