
namespace NohaFMS.Core.Domain

{
    public partial class Cycle : BaseEntity
    {
        public Cycle() { }

        public string Code { get; set; }
        /// <summary>
        /// Gets or sets the value
        /// </summary>
        public string Description { get; set; }
        

        public override string ToString()
        {
            return Name;
        }
    }
}