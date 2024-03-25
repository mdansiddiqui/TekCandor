using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Web;

namespace NohaFMS.Services
{
    public class ChequeDepositService : BaseService, IChequeDepositServices
    {
        #region Fields

        private readonly IRepository<ChequeDepositInformation> _chequeDepositRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<SecurityGroup> _securityGroupRepository;
        private readonly IRepository<SecurityGroupUser> _securityGroupUserRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private readonly HttpContextBase _httpContext;


        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public ChequeDepositService(IRepository<ChequeDepositInformation> chequeDepositRepository, IWorkContext workContext,
            DapperContext dapperContext,
            IDbContext dbContext, IUserActivityService userActivityService, HttpContextBase httpContext
            )
        {
            this._chequeDepositRepository = chequeDepositRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
        }

        #endregion

        #region Methods
        public virtual PagedResult<ChequeDepositInformation> GetChequeDepositInfo(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CheqeDepositSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                //dd
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ChequeDepositInformation.Date");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ChequeDepositSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var ChequeDeposit = connection.Query<ChequeDepositInformation>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ChequeDepositInformation>(ChequeDeposit, totalCount);
            }
        }
        public virtual PagedResult<ChequeDepositInformation> GetAllAssetAuthorizer(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CheqeDepositSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            searchBuilder.Where("Callback = true and Auth=true");
            if (sort != null)
            {
                //dd
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ChequeDepositInformation.Date");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ChequeDepositSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);
                countBuilder.Where("Callback = true and Auth=true");

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var ChequeDeposit = connection.Query<ChequeDepositInformation>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ChequeDepositInformation>(ChequeDeposit, totalCount);
            }
        }
        public virtual PagedResult<ChequeDepositInformation> GetAllAssetsByParentId(string expression,
           dynamic parameters,
           int pageIndex = 0,
           int pageSize = 2147483647,
           IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CheqeDepositCallBackSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
                searchBuilder.Where("status='C' and callback=0");
            if (sort != null)
            {
                //dd
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ChequeDepositInformation.Date");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ChequeDepositCallBackSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);
                countBuilder.Where("status='C' and callback=0");


            using (var connection = _dapperContext.GetOpenConnection())
            {
                var ChequeDeposit = connection.Query<ChequeDepositInformation>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ChequeDepositInformation>(ChequeDeposit, totalCount);
            }
        }


        public virtual PagedResult<ChequeDepositInformation> GetAllAssetsCallBackReturn(string expression,
   dynamic parameters,
   int pageIndex = 0,
   int pageSize = 2147483647,
   IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CheqeDepositSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
                searchBuilder.Where("status='R'");
            if (sort != null)
            {
                //dd
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ChequeDepositInformation.Date");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ChequeDepositSearchCount());
            countBuilder.Where("status='R'");
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var ChequeDeposit = connection.Query<ChequeDepositInformation>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ChequeDepositInformation>(ChequeDeposit, totalCount);
            }
        }


        public virtual PagedResult<ChequeDepositInformation> GetAllAssetsApproved(string expression,
dynamic parameters,
int pageIndex = 0,
int pageSize = 2147483647,
IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CheqeDepositSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            searchBuilder.Where("status='V'");
            if (sort != null)
            {
                //dd
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ChequeDepositInformation.Date");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ChequeDepositSearchCount());
            countBuilder.Where("status='R'");
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var ChequeDeposit = connection.Query<ChequeDepositInformation>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ChequeDepositInformation>(ChequeDeposit, totalCount);
            }
        }

        public void MonitoringActivityFlowlog(long id, string description)
        {
            DateTime dto = System.DateTime.Now;
            //string constr = ConfigurationManager.ConnectionStrings();


            var user = _workContext.CurrentUser;
            string connection = _dapperContext.ConnectionString;


            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                // string desc = "City Created where Id is:" + id.ToString();
                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + description.ToString() + "','" + (user.Id).ToString() + "','" + dto.ToString() + "')";





                //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

                //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


                SqlCommand command = new SqlCommand(query, connect);



                connect.Open();

                //string des = (string)onlyonedesc.ExecuteScalar();
                //h = des;
                //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
                //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

                //SqlCommand command1 = new SqlCommand(query1, connect);

                //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
                //string CustomerName = (string)CmdName.ExecuteScalar();

                command.ExecuteNonQuery();

                connect.Close();

            }

        }

        static long id;
        static DateTime date;

        static string amount, cycleCode, cityCode, serialNo, senderBankCode
            , senderBranchCode, receiverBankCode, receiverBranchCode, chequeNumber, accountNumber,
            sequenceNumber, transactionCode, captureAtNIFT_Branch,
            status, export, returnreasone, error, hubCode, remarks;


        public void ChequeDepositEditBtnLogs(long edit_id)
        {
            var beforeChangeEntities = _chequeDepositRepository.GetById(edit_id);
            
            id = beforeChangeEntities.Id;
            date = beforeChangeEntities.Date;

            amount = Convert.ToString(beforeChangeEntities.Amount);
            cycleCode = beforeChangeEntities.CycleCode;
            cityCode = beforeChangeEntities.CityCode;
            serialNo = beforeChangeEntities.serialNo;
            senderBankCode = beforeChangeEntities.SenderBankCode;
            senderBranchCode = beforeChangeEntities.SenderBranchCode;
            receiverBankCode = beforeChangeEntities.ReceiverBankCode;
            receiverBranchCode = beforeChangeEntities.ReceiverBranchCode;
            chequeNumber = beforeChangeEntities.ChequeNumber;
            accountNumber = beforeChangeEntities.AccountNumber;
            sequenceNumber = beforeChangeEntities.SequenceNumber;
            transactionCode = beforeChangeEntities.TransactionCode;
            captureAtNIFT_Branch = beforeChangeEntities.CaptureAtNIFT_Branch;
            status = beforeChangeEntities.status;
            export = Convert.ToString(beforeChangeEntities.Export);
            returnreasone = beforeChangeEntities.Returnreasone;
            error =Convert.ToString(beforeChangeEntities.Error);
            hubCode = beforeChangeEntities.HubCode;
            remarks = beforeChangeEntities.Remarks;
        }
        public virtual decimal GetLimit(long userId)
        {
            decimal Limit = 0;
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.LimitSearch(userId));
            using (var connection = _dapperContext.GetOpenConnection())
            {
                var UserLimitDetail = connection.Query<NohaFMS.Core.Domain.SecurityGroup>(search.RawSql, search.Parameters);
                Limit = UserLimitDetail.First().UpperLimit;

            }
            return Limit;
        }
        public virtual string GetBranch(long userId)
        {
            string branch = "";
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.BranchSearch(userId));
            using (var connection = _dapperContext.GetOpenConnection())
            {
                var branchDetail = connection.Query<NohaFMS.Core.Domain.Branch>(search.RawSql, search.Parameters);
                branch = branchDetail.First().Code;

            }
            return branch;
        }
        public virtual string GetInstrumentNum(string code)
        {
            string insCode = "";
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.InstrumentNumberSearch(code));
            using (var connection = _dapperContext.GetOpenConnection())
            {
                var insCodeDetail = connection.Query<NohaFMS.Core.Domain.Instrument>(search.RawSql, search.Parameters);
                
                    insCode = insCodeDetail.First().Name;

            }
            return insCode;
        }
        public virtual string GetBranchName(long userId)
        {
            string branchName = "";
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.BranchSearch(userId));
            using (var connection = _dapperContext.GetOpenConnection())
            {
                var branchDetail = connection.Query<NohaFMS.Core.Domain.Branch>(search.RawSql, search.Parameters);
                branchName = branchDetail.First().Name;

            }
            return branchName;
        }
        public virtual string GetHubCode(string hubId)
        {
            string hubName = "";
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.hubSearch(hubId));
            using (var connection = _dapperContext.GetOpenConnection())
            {
                var hubDetail = connection.Query<NohaFMS.Core.Domain.Branch>(search.RawSql, search.Parameters);
                if (hubName != "")
                {
                    hubName = hubDetail.First().Code;
                }

            }
            
            return hubName;
        }

        public void ChequeDepositAfterEditBtnLogs(long after_edit_id)
        {

            var aId = id;
            var aDate = Convert.ToString(date);
            var aAmount = amount;
            var aCycleCode = cycleCode;
            var aCityCode = cityCode;
            var aSerialNo = serialNo;
            var aSenderBankCode = senderBankCode;
            var aReceiverBankCode = receiverBankCode;
            var aReceiverBranchCode = receiverBranchCode;
            var aChequeNumber = chequeNumber;
            var aAccountNumber = accountNumber;
            var aSequenceNumber = sequenceNumber;
            var aTransactionCode = transactionCode;
            var aCaptureatNIFT = captureAtNIFT_Branch;
            var aStatus = status;
            var aReturnReason = returnreasone;
            var aError = error;
            var aHubCode = hubCode;
            var aRemarks = remarks;

            var afterChangeEntities = _chequeDepositRepository.GetById(after_edit_id);

            string sdate, sCycle, sCity, sSerial, sSenderBankCode, sReceiverBankCode, sReceiverBranchCode,
                sChequeNumber, sAccountNumber, sSequenceNumber, sTransactionCode, sAmount, sCapture,
                sStatus, sReturnReason,sError, sHubcode,sRemarks;



                if (Convert.ToString(afterChangeEntities.Date) != aDate)
                {
                    sdate = $" Date ={aDate}->{Convert.ToString(afterChangeEntities.Date)}";
                }
                else { sdate = ""; }

                if (afterChangeEntities.CycleCode != aCycleCode)
                {
                    sCycle = $" CycleCode={aCycleCode}->{afterChangeEntities.CycleCode}";
                }
                else { sCycle = ""; }
            if (Convert.ToString(afterChangeEntities.Error) != aError)
            {
                sError = $" Error={aError}->{Convert.ToString(afterChangeEntities.Error)}";
            }
            else { sError = ""; }

            if (afterChangeEntities.HubCode != aHubCode)
            {
                sHubcode = $" Hub Code={aHubCode}->{afterChangeEntities.HubCode}";
            }
            else { sHubcode = ""; }
            if (afterChangeEntities.CityCode != aCityCode)
                {
                    sCity = $" CityCode={aCityCode}->{afterChangeEntities.CityCode}";
                }
                else { sCity = ""; }
                if (afterChangeEntities.serialNo != aSerialNo)
                {
                    sSerial = $" SerialNo={aSerialNo}->{afterChangeEntities.serialNo}";
                }
                else { sSerial = ""; }
                if (afterChangeEntities.SenderBankCode != aSenderBankCode)
                {
                    sSenderBankCode = $" SenderBankCode={aSenderBankCode}->{afterChangeEntities.SenderBankCode}";
                }
                else
                {
                    sSenderBankCode = "";
                }
                if (afterChangeEntities.ReceiverBankCode != aReceiverBankCode)
                {
                    sReceiverBankCode = $" ReceiverBankCode={aReceiverBankCode}->{afterChangeEntities.ReceiverBankCode}";
                }
                else
                {
                    sReceiverBankCode = "";
                }
                if (afterChangeEntities.ReceiverBranchCode != aReceiverBranchCode)
                {
                    sReceiverBranchCode = $" ReceiverBranchCode={aReceiverBranchCode}->{afterChangeEntities.ReceiverBranchCode}";
                }
                else { sReceiverBranchCode = ""; }
                if (afterChangeEntities.ChequeNumber != aChequeNumber)
                {
                    sChequeNumber = $" ChequeNumber={aChequeNumber}->{afterChangeEntities.ChequeNumber}";
                }
                else { sChequeNumber = ""; }
                if (afterChangeEntities.AccountNumber != aAccountNumber)
                {
                    sAccountNumber = $" AccountNumber={aAccountNumber}->{afterChangeEntities.AccountNumber}";
                }
                else { sAccountNumber = ""; }
                if (afterChangeEntities.SequenceNumber != aSequenceNumber)
                {
                    sSequenceNumber = $" SequenceNumber={aSequenceNumber}->{afterChangeEntities.SequenceNumber}";
                }
                else { sSequenceNumber = ""; }
                if (afterChangeEntities.TransactionCode != aTransactionCode)
                {
                    sTransactionCode = $" TransactionCode={aTransactionCode}->{afterChangeEntities.TransactionCode}";
                }
                else { sTransactionCode = ""; }
                if (Convert.ToString(afterChangeEntities.Amount) != aAmount)
                {
                    sAmount = $" Amount{aAmount}->{Convert.ToString(afterChangeEntities.Amount)}";
                }
                else { sAmount = ""; }
                if (afterChangeEntities.CaptureAtNIFT_Branch != aCaptureatNIFT)
                {
                    sCapture = $" CaptureAtNIFT={aCaptureatNIFT}->{afterChangeEntities.CaptureAtNIFT_Branch}";
                }
                else { sCapture = ""; }
                if (afterChangeEntities.status != aStatus)
                {
                    sStatus = $" Status={aStatus}->{afterChangeEntities.status}";
                }
                else
                {
                    sStatus = "";
                }
                if (afterChangeEntities.Returnreasone != aReturnReason)
                {
                    sReturnReason = $" ReturnReason={aReturnReason}->{afterChangeEntities.Returnreasone}";
                }
                else { sReturnReason = ""; }
                if (afterChangeEntities.Remarks != aRemarks)
                {
                    sRemarks = $" Remarks={aRemarks}->{afterChangeEntities.Remarks}";
                }
                else { sRemarks = ""; }


                string data = $"{sdate}{sCycle}{sCity}{sSerial}{sSenderBankCode}{sReceiverBankCode}{sReceiverBranchCode}" +
                $"{sChequeNumber}{sAccountNumber}{sSequenceNumber}{sTransactionCode}{sAmount}{sCapture}" +
                $"{sStatus}{sReturnReason}{sError}{sHubcode}{sRemarks}";
                if (data == "")
                {
                    data = "Searched for Nothing";
                }
                else
                {
                    string operation1;
                if (sdate == null && sCycle == null && sCity == null && sSerial == null && sSenderBankCode == null && sReceiverBankCode == null && sReceiverBranchCode == null &&
            sChequeNumber == null && sAccountNumber == null && sSequenceNumber == null && sTransactionCode == null && sAmount == null && sCapture == null &&
            sStatus == null && sReturnReason == null && sRemarks == null)
                {
                    operation1 = "";
                }
                else { operation1 = $"Cheque has been Modify Proceed with id={after_edit_id}"; }



                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation1} {data}");
                    
                }
            }

           
        

        public void searchFilterLogs(string date, string receiver, string cheque,
            string error,
            string hub, string rReason,string branch, string status)
        {
            string fdate, freceiver, fcheque, ferror, fhub, freason, fbranch, fstatus;


            if (date == null || date == "")
            {
                fdate = $"{date}";
            }
            else
            {
                fdate = $" Date = {date},";
            }

            if (receiver == null || receiver == "")
            {
                receiver = "";
                freceiver = $"{receiver}";
            }
            else
            {
                freceiver = $" Receiver Bank Code = {receiver},";
            }
            if (cheque == null || cheque == "")
            {
                cheque = "";
                fcheque = $"{cheque}";
            }
            else { fcheque = $" Cheque Number = {cheque},"; }
            if (error == null||error=="")
            {

                ferror = $"{error}";
            }
            else { 
                ferror = $" Error = {error},"; 
            }
            if (hub == null || hub == "")
            {
                hub = "";
                fhub = $"{hub}";
            }
            else { fhub = $" Hub Code = {hub}"; }
            if (rReason == null || rReason == "")
            {
                rReason = "";
                freason = $"{rReason}";
            }
            else
            {
                freason = $" Return Reason = {rReason}";
            }

            if (branch == null || branch == "")
            {
                fbranch = $"{branch}";
            }
            else
            {
                fbranch = $" BranchId = {branch}";
            }


            if (status == null || status == "")
            {
                fstatus = $"{status}";
            }
            else
            {
                fstatus = $" Status = {status}";
            }

            string data = $"{fdate}{freceiver}{fcheque}{ferror}{fhub}{freason.Replace("'", "''")}{fstatus}{fbranch}";

            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string desc = $"Searched for {data}";

                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);

            }

        }


    }
    #endregion
}