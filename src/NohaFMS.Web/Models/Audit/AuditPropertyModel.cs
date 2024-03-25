/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;

namespace NohaFMS.Web.Models
{
    public class AuditPropertyModel
    {
        [BaseEamResourceDisplayName("AuditProperty.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("AuditProperty.Type")]
        public string Type { get; set; }

        [BaseEamResourceDisplayName("AuditProperty.Current")]
        public string Current { get; set; }

        [BaseEamResourceDisplayName("AuditProperty.Original")]
        public string Original { get; set; }
    }
}