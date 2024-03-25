using System;

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Contains user's preferences in the current session
    /// </summary>
    [Serializable]
    public class UserPreferences
    {
        public bool SidebarCollapsed { get; set; }
    }
}
