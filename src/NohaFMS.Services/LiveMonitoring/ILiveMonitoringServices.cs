using NohaFMS.Core;
using NohaFMS.Core.Domain;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface ILiveMonitoringServices : IBaseService
    {
        PagedResult<LiveMonitoring> GetLiveMonitoring(string expression,
       dynamic parameters,
       int pageIndex = 0,
       int pageSize = 2147483647,
       IEnumerable<Core.Kendoui.Sort> sort = null); //Int32.MaxValue 

        List<LiveMonitoring> GetAllAssetsByParentId(string name, string branchname, string branchcode);

        void MonitoringActivityFlowlog(long id, string description);

    }

}
