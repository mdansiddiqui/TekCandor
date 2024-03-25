/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;

namespace NohaFMS.Web.Models
{
    public class UserDashboardModel
    {
        [BaseEamResourceDisplayName("User")]
        public string UserId { get; set; }

        [BaseEamResourceDisplayName("UserDashboard.DashboardLayoutType")]
        public DashboardLayoutType DashboardLayoutType { get; set; }

        [BaseEamResourceDisplayName("UserDashboard.RegionCount")]
        public int? RegionCount { get; set; }
    }
}