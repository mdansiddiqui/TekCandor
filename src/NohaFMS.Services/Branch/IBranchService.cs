using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.Branch
{
    public interface IBranchService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.Branch> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 

        void searchFilterLog(string fBranchName);
        void Klog(long id, string description);
        void branchBeforeEditBtnLog(long id);
        void branchAfterEditBtnLog(long id,bool IsCreate);

    }
}
