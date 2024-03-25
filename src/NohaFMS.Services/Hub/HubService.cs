using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NohaFMS.Services.Hub
{
    public class HubService : BaseService, IHubService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.Hub> _hubRepository;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public HubService(IRepository<NohaFMS.Core.Domain.Hub> hubRepository, DapperContext dapperContext
                    , IDbContext dbContext,IUserActivityService userActivityService, HttpContextBase httpContext,IWorkContext workContext)
        {
            this._hubRepository = hubRepository;
            this._dapperContext = dapperContext;
            this._dbContext = dbContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
            this._workContext = workContext;

        }

        #endregion

        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.Hub> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.HubSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Code");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.HubSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var hubs = connection.Query<NohaFMS.Core.Domain.Hub>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.Hub>(hubs, totalCount);
            }
        }

        static string ctname, ctcode;
            static long ccity;

        //UserActivityLog
        public void Klog(long id, string description)
        {    
            ctname = null;
            ctcode = null;
            ccity = 0;
        }

        public void searchFilterLog(string fHubName)
        {
            string hubname;
          

                if (fHubName == null || fHubName == "")
                {
                    fHubName = "";
                    hubname = $"{fHubName}";
                }
                else
                {
                    hubname = $"Hub Name = {fHubName}";
                }

                string data = $"{hubname}";
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

        public void hubBeforeEditBtnLog(long id)
        {
            var hub = _hubRepository.GetById(id);
            ctcode = hub.Code;
            ctname = hub.Name;
            ccity = (long)hub.CityId;
        }

        public void hubAfterEditBtnLog(long id,bool isCreated)
        {

            var hubName = ctname;
            var hubCode = ctcode;
            var hubCity = ccity;
            var afterChange = _hubRepository.GetById(id);
            string cName, cCode,cCity;
            

            if (afterChange.Name != hubName)
            {
                cName = $" Name= {hubName}->{afterChange.Name},";
            }
            else { cName = ""; }
            if (afterChange.Code != hubCode)
            {
                    cCode = $" Code= {hubCode}->{afterChange.Code}";
            }
            else { cCode = ""; }
            if (afterChange.CityId != hubCity)
            {
                cCity = $" CityId={hubCity}->{afterChange.CityId}";
            }
            else { cCity = ""; }


            string data = $"{cName}{cCode}{cCity}";

            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string operation;
                if (isCreated==true)
                {
                    operation = $"Hub has been created with Id={id}";
                }
                else
                {
                        operation = $"Hub Modified of Id={id}, Name and Code are: " + afterChange.Name + "-" + afterChange.Code;
                }
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation}  {data}");
            }
        }
        #endregion
    }
}
