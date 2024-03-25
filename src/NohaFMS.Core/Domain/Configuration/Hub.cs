
using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Represents a setting
    /// </summary>
    public partial class Hub : BaseEntity
    {
        public Hub() { }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Code { get; set; }
        public long? CityId { get; set; }
        [Write(false)]
        public virtual City City { get; set; }
        
        private ICollection<Branch> _branch;
        [Write(false)]
        public virtual ICollection<Branch> Branchs
        {
            get { return _branch ?? (_branch = new List<Branch>()); }
            protected set { _branch = value; }
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
