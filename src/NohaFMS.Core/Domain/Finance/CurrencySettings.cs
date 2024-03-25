/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Configuration;
using System;

namespace NohaFMS.Core.Domain
{
    public class CurrencySettings : ISettings
    {
        public bool DisplayCurrencyLabel { get; set; }
        public long PrimarySystemCurrencyId { get; set; }
        public long PrimaryExchangeRateCurrencyId { get; set; }
        public bool AutoUpdateEnabled { get; set; }
        public DateTime? LastUpdateTime { get; set; }
    }
}
