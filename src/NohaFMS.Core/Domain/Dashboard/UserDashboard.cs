/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class UserDashboard : BaseEntity
    {
        public long? UserId { get; set; }
        public virtual User User { get; set; }

        public int? DashboardLayoutType { get; set; }
        public int? RegionCount { get; set; }

        private ICollection<UserDashboardVisual> _userDashboardVisuals;
        public virtual ICollection<UserDashboardVisual> UserDashboardVisuals
        {
            get { return _userDashboardVisuals ?? (_userDashboardVisuals = new List<UserDashboardVisual>()); }
            protected set { _userDashboardVisuals = value; }
        }
    }

    public enum DashboardLayoutType
    {
        HeroSidebar = 0,
        HeroThirds,
        QuarterGrid,
        SplitCentered,
        SplitColumns,
        SplitRows,
        ThirdsGrid,
        TwoAndOne
    }
}
