﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// This represents a site in NohaFMS multi-site architecture
    /// </summary>
    public partial class Site : BaseEntity
    {
        public string Description { get; set; }

        public long? OrganizationId { get; set; }
        public virtual Organization Organization { get; set; }

        private ICollection<SecurityGroup> _securityGroups;
        public virtual ICollection<SecurityGroup> SecurityGroups
        {
            get { return _securityGroups ?? (_securityGroups = new List<SecurityGroup>()); }
            protected set { _securityGroups = value; }
        }

        private ICollection<Address> _addresses;
        public virtual ICollection<Address> Addresses
        {
            get { return _addresses ?? (_addresses = new List<Address>()); }
            protected set { _addresses = value; }
        }
    }
}
