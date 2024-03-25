/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class ReturnItem : BaseEntity
    {
        public long? ReturnId { get; set; }
        public virtual Return Return { get; set; }

        public long? IssueItemId { get; set; }
        public virtual IssueItem IssueItem { get; set; }

        public decimal? ReturnQuantity { get; set; }
        public decimal? ReturnCost { get; set; }
    }
}
