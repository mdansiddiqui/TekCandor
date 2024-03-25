using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.Hub
{
    public interface IHubService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.Hub> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 
        void Klog(long id, string description);
        void searchFilterLog(string fHubName);
        void hubBeforeEditBtnLog(long id);
        void hubAfterEditBtnLog(long id, bool isCreated);

    }
}