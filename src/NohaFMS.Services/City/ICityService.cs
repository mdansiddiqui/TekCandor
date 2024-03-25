using NohaFMS.Core;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface ICityService : IBaseService
    {
    PagedResult<NohaFMS.Core.Domain.City> GetAttributes(string expression,
    dynamic parameters,
    int pageIndex = 0,
    int pageSize = 2147483647,
    IEnumerable<Sort> sort = null); //Int32.MaxValue 
        void searchFilterLog(string fCityName);

        void Klog(long id, string description);
        void cityBeforeEditBtnLog(long id);
        void cityAfterEditBtnLog(long id,bool isCreated);
        
    }
}
