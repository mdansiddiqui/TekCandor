using Dapper.Contrib.Extensions;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain

{
    public partial class Bank : BaseEntity
    {
        public Bank() { }


        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Code { get; set; }
        
        public override string ToString()
        {
            return Name;
        }
    }
}