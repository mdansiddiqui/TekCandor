using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NohaFMS.Services.Branch
{
    public class BranchService : BaseService, IBranchService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.Branch> _branchRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private HttpContextBase _httpContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public BranchService(IRepository<NohaFMS.Core.Domain.Branch> branchRepository, DapperContext dapperContext
                    , IDbContext dbContext, IWorkContext workContext,IUserActivityService userActivityService,HttpContextBase httpContext)
        {
            this._branchRepository = branchRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
        }

      
        #endregion

        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.Branch> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.BranchSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Name");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.BranchSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var branchies = connection.Query<NohaFMS.Core.Domain.Branch>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.Branch>(branchies, totalCount);
            }
        }

        public void Klog(long id, string description)
        {
            ctname = null;
            ctcode = null;
            cnift = null;
            cemail = null;
            hubid = 0;
        }


        static string ctname, ctcode,cnift,cemail;
        static long hubid;

        public void searchFilterLog(string fBranchName)
        {
            string branchname;
            

                if (fBranchName == null || fBranchName == "")
                {
                    fBranchName = "";
                    branchname = $"{fBranchName}";
                }
                else
                {
                    branchname = $"Branch Name = {fBranchName}";
                }

                string data = $"{branchname}";
                if (data == "")
                {
                    data = "Searched for Nothing";
                }
                else if(data != "")
                {
                    _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl,$"Searched for {data}");
                    
                
                }
        }

        public void branchBeforeEditBtnLog(long id)
        {
            var branch = _branchRepository.GetById(id);
            ctcode = branch.Code;
            ctname = branch.Name;
            cemail = branch.Email;
            cnift = branch.NIFTBranchCode;
            hubid = (long)branch.HubId;
        }

        public void branchAfterEditBtnLog(long id, bool IsCreate)
        {
            var beforeBranchName = ctname;
            var beforeBranchCode = ctcode;
            var beforeBranchNIFT = cnift;
            var beforeBranchhubid = hubid;
            var beforeBranchEmail = cemail;
           
            var afterChange = _branchRepository.GetById(id);

            string cName, cCode,bnift,bhub,bemail;
           
                if (afterChange.Name != beforeBranchName)
                {
                    cName = $" Name= {beforeBranchName}->{afterChange.Name},";
                }
                else { cName = ""; }
                if (afterChange.Code != beforeBranchCode)
                {
                    cCode = $" Code= {beforeBranchCode}->{afterChange.Code},";
                }
                else { cCode = ""; }


                if (afterChange.NIFTBranchCode != beforeBranchNIFT)
                {
                    bnift = $" NIFT Code= {beforeBranchNIFT}->{afterChange.NIFTBranchCode},";
                }
                else { bnift = ""; }
                if (afterChange.HubId != beforeBranchhubid)
                {
                    bhub = $" Hub= {beforeBranchhubid}->{afterChange.HubId},";
                }
                else { bhub = ""; }
                if (afterChange.Email != beforeBranchEmail)
                {
                    bemail = $" Email= {beforeBranchEmail}->{afterChange.Email},";
                }
                else { bemail = ""; }

                string data = $"{cName}{cCode}{bnift}{bhub}{bemail}";

                if (data == "")
                {
                    data = "Searched for Nothing";
                }
                else
                {
                    string operation;
                    if (IsCreate == true)
                    {

                        operation = $"Branch has been created with Id={id}";
                        
                    }
                    else
                    {
                        operation = $"Branch Modified of Id={id}, Name and Code are: " + afterChange.Name + "-" + afterChange.Code;
                    }
                  
                   
                   _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation}   {data}");

                   
                }
            



        }


        #endregion
    }
}
