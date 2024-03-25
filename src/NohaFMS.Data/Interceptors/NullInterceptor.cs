using System.Data.Entity.Infrastructure.Interception;

namespace NohaFMS.Data.Interceptors
{
    public class NullInterceptor : IDbCommandTreeInterceptor
    {
        public void TreeCreated(DbCommandTreeInterceptionContext interceptionContext)
        {
            return;
        }
    }
}
