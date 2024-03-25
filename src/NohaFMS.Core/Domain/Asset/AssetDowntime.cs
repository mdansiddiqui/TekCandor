/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class AssetDowntime : BaseEntity
    {
        public long? AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public DateTime? StartDateTime { get; set; }
        public DateTime? EndDateTime { get; set; }

        public long? DowntimeTypeId { get; set; }
        public virtual ValueItem DowntimeType { get; set; }

        public DateTime? ReportedDateTime { get; set; }

        public long? ReportedUserId { get; set; }
        public virtual User ReportedUser { get; set; }
    }
}
