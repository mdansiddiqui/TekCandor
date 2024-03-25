using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IMeterGroupService : IBaseService
    {
        PagedResult<MeterGroup> GetMeterGroups(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<MeterGroup> GetMeterGroupList(string param);
        
        void AssetActivityFlowlog(long id, string description);

    }
}
