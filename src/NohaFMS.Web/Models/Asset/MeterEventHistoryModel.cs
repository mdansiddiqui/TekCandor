/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;

namespace NohaFMS.Web.Models
{
    public class MeterEventHistoryModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("MeterEvent")]
        public long? MeterEventId { get; set; }
        public string MeterEventName { get; set; }

        //Cache AssetId, Location in PM
        [BaseEamResourceDisplayName("Asset")]
        public long? AssetId { get; set; }

        [BaseEamResourceDisplayName("Location")]
        public long? LocationId { get; set; }

    }
}