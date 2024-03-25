

namespace NohaFMS.Core.Domain
{
    public partial class SecurityGroupUser:BaseEntity
    {
        public long SecurityGroupid { get; set; }
        public long UserId { get; set; }
    }
}
