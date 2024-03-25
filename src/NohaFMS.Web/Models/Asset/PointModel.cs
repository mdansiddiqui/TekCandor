/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;

namespace NohaFMS.Web.Models
{
    public class PointModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Location")]
        public long? LocationId { get; set; }
        public virtual LocationModel Location { get; set; }

        [BaseEamResourceDisplayName("Asset")]
        public long? AssetId { get; set; }
        public AssetModel Asset { get; set; }

        [BaseEamResourceDisplayName("MeterGroup")]
        public long? MeterGroupId { get; set; }
        public MeterGroupModel MeterGroup { get; set; }
    }
}