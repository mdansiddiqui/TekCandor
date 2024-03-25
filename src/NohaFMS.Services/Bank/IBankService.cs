using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.Bank
{
    public interface IBankService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.Bank> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 
    }
}
