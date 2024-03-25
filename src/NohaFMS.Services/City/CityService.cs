using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NohaFMS.Services.City

{
    public class CityService : BaseService, ICityService
    {
        #region Fields

        private readonly IRepository<NohaFMS.Core.Domain.City> _cityRepository;
        private readonly IUserActivityService _userActivityService;
        private readonly DapperContext _dapperContext;
        private readonly IDbContext _dbContext;
        private readonly IWorkContext _workContext;
        private readonly HttpContextBase _httpContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public CityService(IRepository<NohaFMS.Core.Domain.City> cityRepository,
            IUserActivityService userActivityService,
            DapperContext dapperContext
                    ,IDbContext dbContext,IWorkContext workContext,
            HttpContextBase httpContext)
        {
            this._cityRepository = cityRepository;
            this._dapperContext = dapperContext;
            this._userActivityService = userActivityService;
            this._dbContext = dbContext;
            this._workContext = workContext;
            this._httpContext = httpContext;
          
        }

        #endregion

        #region Methods

        public virtual PagedResult<NohaFMS.Core.Domain.City> GetAttributes(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.CitySearch(), new { skip = pageIndex * pageSize, take = pageSize });
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
            var count = countBuilder.AddTemplate(SqlTemplate.CitySearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var cities = connection.Query<NohaFMS.Core.Domain.City>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<NohaFMS.Core.Domain.City>(cities, totalCount);
            }
        }

        public void searchFilterLog(string fCityName)
        {
            string cityname;
                if (fCityName == null || fCityName == "")
                {
                    fCityName = "";
                    cityname = $"{fCityName}";
                }
                else
                {
                    cityname = $"City Name = {fCityName}";
                }

                string data = $"{cityname}";
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
        static string ctname, ctcode;
        
        //UserActivityLog
        public void Klog(long id, string description)
        {
                ctname = null;
                ctcode = null;
        }
        
        public void cityBeforeEditBtnLog(long id)
        {
           var city12 =_cityRepository.GetById(id);
           ctcode = city12.Code;
           ctname = city12.Name;
        }

        public void cityAfterEditBtnLog(long id,bool isCreated)
        {
            var cityName = ctname;
            var cityCode = ctcode;

            var cityAfter = _cityRepository.GetById(id);
            var afterCityName = cityAfter.Name;
            var afterCityCode = cityAfter.Code;
            string cName, cCode;


            if (afterCityName != cityName)
            {
                cName = $" Name= {cityName}->{afterCityName},";
            }
            else { cName = ""; }
            if (afterCityCode != cityCode)
            {
                cCode = $" Code= {cityCode}->{afterCityCode}";
            }
            else { cCode = ""; }
            
            string data = $"{cName}{cCode}";

                if (data == "")
                {
                    data = "Searched for Nothing";
                }
                else
                {
                    string operation;
                    if (isCreated==true)
                    {
                        operation = $"City has been created with Id={id}";
                    }
                    else
                    {
                        operation = $"City Modified of Id={id}, Name and Code are: " + afterCityName + "-" + afterCityCode;
                    }
               
                    _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation} {data}");                
                }
        }
        #endregion
    }
}
