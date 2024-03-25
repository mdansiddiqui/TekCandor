using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;

using System.Collections.Generic;


namespace NohaFMS.Services
{
    public interface IChequeDepositServices : IBaseService
    {
        PagedResult<ChequeDepositInformation> GetChequeDepositInfo(string expression,
                  dynamic parameters,
                  int pageIndex = 0,
                  int pageSize = 2147483647,
                  IEnumerable<Sort> sort = null); //Int32.MaxValue

        PagedResult<ChequeDepositInformation> GetAllAssetsByParentId(string expression,
                  dynamic parameters, int pageIndex = 0,int pageSize = 2147483647,
                  IEnumerable<Sort> sort = null);
        PagedResult<ChequeDepositInformation> GetAllAssetsCallBackReturn(string expression,
          dynamic parameters,
          int pageIndex = 0,
          int pageSize = 2147483647,
          IEnumerable<Sort> sort = null);

        PagedResult<ChequeDepositInformation> GetAllAssetsApproved(string expression,
          dynamic parameters,
          int pageIndex = 0,
          int pageSize = 2147483647,
          IEnumerable<Sort> sort = null);
        void MonitoringActivityFlowlog(long id, string v);
        void ChequeDepositAfterEditBtnLogs(long id);
        void ChequeDepositEditBtnLogs(long id);
        PagedResult<ChequeDepositInformation> GetAllAssetAuthorizer(string expression,
                  dynamic parameters,
                  int pageIndex = 0,
                  int pageSize = 2147483647,
                  IEnumerable<Sort> sort = null);
        decimal GetLimit(long userId);
        void searchFilterLogs(string date, string receiver, string cheque,
            string error,string hub,string rReason,string fBranch,string status);
        string GetBranch(long userId);
        string GetInstrumentNum(string code);
        string GetBranchName(long userId);
        string GetHubCode(string hubId);
        //void Klog(long id, string description);
    }


}
