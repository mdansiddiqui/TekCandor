using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services.ReturnReason
{
    public interface IReturnReasonService : IBaseService
    {
        PagedResult<NohaFMS.Core.Domain.ReturnReason> GetAttributes(string expression,
        dynamic parameters,
        int pageIndex = 0,
        int pageSize = 2147483647,
        IEnumerable<Sort> sort = null); //Int32.MaxValue 

        void searchFilterLog(string fReturnReasonName);
        void returnReasonBeforeEditBtnLog(long id);
        void returnReasonAfterEditBtnLog(long id, bool isCreate);
    }
}