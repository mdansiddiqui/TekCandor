/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public partial class City : BaseEntity
    {
        public City() { }


        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Code { get; set; }

        private ICollection<Hub> _hub;
        [Write(false)]
        public virtual ICollection<Hub> Hubs
        {
            get { return _hub ?? (_hub = new List<Hub>()); }
            protected set { _hub = value; }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
