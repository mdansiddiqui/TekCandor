using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NohaFMS.Services.Cycle
{
    public class CycleService : BaseService, ICycleService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.Cycle> _cycleRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        private readonly IWorkContext _workContext;
        private readonly HttpContextBase _httpContext;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public CycleService(IRepository<NohaFMS.Core.Domain.Cycle> cycleRepository, DapperContext dapperContext
                    , IDbContext dbContext,IUserActivityService userActivityService,IWorkContext workContext,HttpContextBase httpContext)
        {
            this._cycleRepository = cycleRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
            this._workContext = workContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.Cycle> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CycleSearch(), new { skip = pageIndex * pageSize, take = pageSize });
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
            var count = countBuilder.AddTemplate(SqlTemplate.CycleSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var cycles = connection.Query<NohaFMS.Core.Domain.Cycle>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.Cycle>(cycles, totalCount);
            }
        }

        public void searchFilterLog(string fCycleName)
        {
            string cyclename;


            if (fCycleName == null || fCycleName == "")
            {
                fCycleName = "";
                cyclename = $"{fCycleName}";
            }
            else
            {
                cyclename = $"Cycle Name = {fCycleName}";
            }

            string data = $"{cyclename}";
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
        static string cyName, cyDescription;

        //UserActivityLog
        public void Klog(long id, string description)
        {
            cyName = null;
            cyDescription = null;
        }

        public void cycleBeforeEditBtnLog(long id)
        {
            var cycle = _cycleRepository.GetById(id);
            cyDescription = cycle.Description;
            cyName = cycle.Name;
        }

        public void cycleAfterEditBtnLog(long id, bool isCreated)
        {

            var beforeCycleName = cyName;
            var beforeCycleDescription = cyDescription;

            var afterChange = _cycleRepository.GetById(id);
            string cName, cDesc;


            if (afterChange.Name != beforeCycleName)
            {
                cName = $" Name= {beforeCycleName}->{afterChange.Name},";
            }
            else { cName = ""; }
            if (afterChange.Description != beforeCycleDescription)
            {
                cDesc = $" Description= {beforeCycleDescription}->{afterChange.Description}";
            }
            else { cDesc = ""; }

            string data = $"{cName}{cDesc}";

            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string operation;
                if (isCreated == true)
                {
                    operation = $"Cycle has been created with Id={id}";
                }
                else
                {
                    operation = $"Cycle Modified of Id={id}, Name and Description are: " + afterChange.Name + "-" + afterChange.Description;
                }

                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation} {data}");
            }
        }
        #endregion
    }
}
