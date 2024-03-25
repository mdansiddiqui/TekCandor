/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class PMMeterFrequency : BaseEntity
    {
        public long? PreventiveMaintenanceId { get; set; }
        public virtual PreventiveMaintenance PreventiveMaintenance { get; set; }

        public decimal? Frequency { get; set; }
        public decimal? EndReading { get; set; }
        public decimal? GeneratedReading { get; set; }

        public long? MeterId { get; set; }
        public virtual Meter Meter { get; set; }
    }
}
