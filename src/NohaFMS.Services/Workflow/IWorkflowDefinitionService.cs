using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IWorkflowDefinitionService : IBaseService
    {
        PagedResult<WorkflowDefinition> GetWorkflowDefinitions(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null);
        void WorkflowActivityFlowlog(long id, string description);
    }
}
