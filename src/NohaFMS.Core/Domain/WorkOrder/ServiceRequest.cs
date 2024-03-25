/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class ServiceRequest : WorkflowBaseEntity
    {
        public long? SiteId { get; set; }
        public virtual Site Site { get; set; }

        public long? AssetId { get; set; }
        public virtual Asset Asset { get; set; }

        public long? LocationId { get; set; }
        public virtual Location Location { get; set; }

        public int? RequestorType { get; set; }
        public string RequestorName { get; set; }
        public string RequestorEmail { get; set; }
        public string RequestorPhone { get; set; }
        public DateTime? RequestedDateTime { get; set; }

        public bool SLAEnabled { get; set; }

        private ICollection<WorkOrder> _workOrders;
        public virtual ICollection<WorkOrder> WorkOrders
        {
            get { return _workOrders ?? (_workOrders = new List<WorkOrder>()); }
            protected set { _workOrders = value; }
        }
    }

    public enum RequestorType
    {
        User = 0,
        Public
    }
}
