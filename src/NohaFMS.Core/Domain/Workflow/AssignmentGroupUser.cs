/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class AssignmentGroupUser : BaseEntity
    {
        public long? AssignmentGroupId { get; set; }
        public virtual AssignmentGroup AssignmentGroup { get; set; }

        public long? SiteId { get; set; }
        public virtual Site Site { get; set; }

        public long? UserId { get; set; }
        public virtual User User { get; set; }

        public bool IsDefaultUser { get; set; }
    }
}
