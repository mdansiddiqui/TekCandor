/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class Craft : BaseEntity
    {
        public string Description { get; set; }

        /// <summary>
        /// Standard hourly rate
        /// </summary>
        public decimal? StandardRate { get; set; }

        /// <summary>
        /// Overtime hourly rate
        /// </summary>
        public decimal? OvertimeRate { get; set; }
    }
}
