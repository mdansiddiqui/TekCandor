using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.PasswordPolicy
{
    public interface IPasswordPolicyService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.PasswordPolicy> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 
    }
}