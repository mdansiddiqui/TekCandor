/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class Return : BaseEntity
    {
        public string Number { get; set; }
        public string Description { get; set; }
        public DateTime? ReturnDate { get; set; }

        public long? SiteId { get; set; }
        public virtual Site Site { get; set; }

        public long? StoreId { get; set; }
        public virtual Store Store { get; set; }

        public long? WorkOrderId { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }

        public bool IsApproved { get; set; }

        private ICollection<ReturnItem> _returnItems;
        public virtual ICollection<ReturnItem> ReturnItems
        {
            get { return _returnItems ?? (_returnItems = new List<ReturnItem>()); }
            protected set { _returnItems = value; }
        }
    }
}
