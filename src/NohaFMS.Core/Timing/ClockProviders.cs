/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Timing
{
    public static class ClockProviders
    {
        public static UtcClockProvider Utc { get; } = new UtcClockProvider();
    }
}
