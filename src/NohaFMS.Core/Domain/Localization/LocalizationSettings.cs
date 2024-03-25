/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Configuration;

namespace NohaFMS.Core.Domain
{
    public class LocalizationSettings : ISettings
    {
        /// <summary>
        /// Default language identifier
        /// </summary>
        public long DefaultLanguageId { get; set; }

        /// <summary>
        /// A value indicating whether to load all LocaleStringResource records on application startup
        /// </summary>
        public bool LoadAllLocaleRecordsOnStartup { get; set; }
    }
}
