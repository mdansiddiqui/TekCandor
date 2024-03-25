
using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain

{
     public partial class Branch : BaseEntity
    {
        public Branch() { }


        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Code { get; set; }
        public string NIFTBranchCode { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }

        public long? HubId { get; set; }
        [Write(false)]
        public virtual Hub Hub { get; set; }

        
        public override string ToString()
        {
            return Name;
        }
    }
}