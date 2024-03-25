/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Web.Models
{
    public class AccessControlModel
    {
        public long SecurityGroupId { get; set; }

        public string Name { get; set; }

        public bool HasPermission { get; set; }
    }
}