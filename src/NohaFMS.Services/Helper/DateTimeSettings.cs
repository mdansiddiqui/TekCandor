/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Configuration;

namespace NohaFMS.Services
{
    public class DateTimeSettings : ISettings
    {
        /// <summary>
        /// Gets or sets a value indicating whether users are allowed to select theirs time zone
        /// </summary>
        public bool AllowUsersToSetTimeZone { get; set; }
    }
}