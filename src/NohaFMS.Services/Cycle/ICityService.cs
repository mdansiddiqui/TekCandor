using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.Cycle
{
    public interface ICycleService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.Cycle> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 
        void searchFilterLog(string fCycleName);
        void Klog(long id, string description);
        void cycleBeforeEditBtnLog(long id);
        void cycleAfterEditBtnLog(long id, bool isCreated);
    }
}
