using System.Security;
using System.Security.Claims;
using System.Security.Principal;
using System.Web.Security;

namespace NohaFMS.Core.Domain.Security
{
    public class NohaFMSIdentity : ClaimsIdentity
    {
        [SecuritySafeCritical]
        public NohaFMSIdentity(long userId, string name, string type)
            : base(new GenericIdentity(name, type))
        {
            UserId = userId;
        }

        public long UserId { get; private set; }

        public override bool IsAuthenticated { get { return UserId != 0; } }
    }


    public class NohaFMSPrincipal : IPrincipal
    {
        public NohaFMSPrincipal(User user, string type)
        {
            this.Identity = new NohaFMSIdentity(user.Id, user.LoginName, type);
        }

        public bool IsInRole(string role)
        {
            return (Identity != null && Identity.IsAuthenticated && !string.IsNullOrWhiteSpace(role) && Roles.IsUserInRole(Identity.Name, role));
        }

        public IIdentity Identity { get; private set; }
    }
}
