/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using System;

namespace NohaFMS.Web.Models
{
    public class SystemInfoModel
    {
        [BaseEamResourceDisplayName("SystemInfo.BaseEamVersion")]
        public string BaseEamVersion { get; set; }

        [BaseEamResourceDisplayName("SystemInfo.ServerLocalTime")]
        public DateTime ServerLocalTime { get; set; }

        [BaseEamResourceDisplayName("SystemInfo.ServerTimeZone")]
        public string ServerTimeZone { get; set; }

        [BaseEamResourceDisplayName("SystemInfo.UTCTime")]
        public DateTime UtcTime { get; set; }

        [BaseEamResourceDisplayName("SystemInfo.CurrentUserTime")]
        public DateTime CurrentUserTime { get; set; }
    }
}