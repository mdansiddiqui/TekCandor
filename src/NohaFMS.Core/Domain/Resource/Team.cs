/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class Team : BaseEntity
    {
        public string Description { get; set; }

        public long? SiteId { get; set; }
        public virtual Site Site { get; set; }

        private ICollection<Technician> _technicians;
        public virtual ICollection<Technician> Technicians
        {
            get { return _technicians ?? (_technicians = new List<Technician>()); }
            protected set { _technicians = value; }
        }
    }
}
