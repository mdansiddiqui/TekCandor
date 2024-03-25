/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Timing
{
    public static class TimeZoneHelper
    {
        public static DateTime? Convert(DateTime? date, string fromTimeZoneId, string toTimeZoneId)
        {
            if (!date.HasValue)
            {
                return null;
            }

            var sourceTimeZone = TimeZoneInfo.FindSystemTimeZoneById(fromTimeZoneId);
            var destinationTimeZone = TimeZoneInfo.FindSystemTimeZoneById(toTimeZoneId);
            return TimeZoneInfo.ConvertTime(date.Value, sourceTimeZone, destinationTimeZone);
        }

        public static DateTime? ConvertFromlocal(DateTime? date, string toTimeZoneId)
        {
            return Convert(date, "Local", toTimeZoneId);
        }

        public static DateTime? ConvertTolocal(DateTime? date, string fromTimeZoneId)
        {
            return Convert(date, fromTimeZoneId, "Local");
        }
    }
}
