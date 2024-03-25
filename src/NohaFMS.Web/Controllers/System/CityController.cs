/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using NohaFMS.Services;
using NohaFMS.Web.Extensions;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Framework.CustomField;
using NohaFMS.Web.Framework.Session;
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NohaFMS.Web.Framework.Filters;



namespace NohaFMS.Web.Controllers
{
    public class CityController : BaseController
    {
        #region Fields

        private readonly IRepository<City> _cityRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private readonly HttpContextBase _httpContext;
        private readonly ICityService _cityService;
        private readonly IDbContext _dbContext;
        #endregion

        #region Constructors

        public CityController(IRepository<City> cityRepository, IUserActivityService userActivityService,
                                IWorkContext workContext,
                              ILocalizationService localizationService, 
                              //IRepository<IUserActivityLogs> userActivityLogsrepo,
                              HttpContextBase httpContext,ICityService cityService, IDbContext dbContext)
        {
            this._cityRepository = cityRepository;
            //this._userActivityLogsRepository = userActivityLogsrepo;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._cityService = cityService;
            this._dbContext = dbContext;
        }

        #endregion

        string ur;
        #region Utilities
        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            var attributeNameFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "CityName",
                ResourceKey = "System.CityName",
                DbColumn = "Name",
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(attributeNameFilter);
            //var cityNameFilter = new FieldModel
            //{
            //    DisplayOrder = 2,
            //    Name = "CityName",
            //    ResourceKey = "System.CityName",
            //    DbColumn = "City.Id",
            //    Value = null,
            //    ControlType = FieldControlType.DropDownList,
            //    DataType = FieldDataType.Int64,
            //    DataSource = FieldDataSource.DB,
            //    DbTable = "City",
            //    DbTextColumn = "Name",
            //    DbValueColumn = "Id",
            //    IsRequiredField = false
            //};
            //model.Filters.Add(cityNameFilter);

            return model;
        }
        #endregion

        #region Methods

        public ActionResult List()
        {

            var model = _httpContext.Session[SessionKey.AttributeSearchModel] as SearchModel;
            //If not exist, build search model
            if (model == null)
            {
                model = BuildSearchModel();
                //session save
                _httpContext.Session[SessionKey.AttributeSearchModel] = model;
            }
            return View(model);
        }
        

        [HttpPost]
        public ActionResult List(DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "City");

            var model = _httpContext.Session[SessionKey.AttributeSearchModel] as SearchModel;
            if (model == null)
                model = BuildSearchModel();
            else
                model.ClearValues();
            //validate
            var errorFilters = model.Validate(searchValues);
            foreach (var filter in errorFilters)
            {
                ModelState.AddModelError(filter.Name, _localizationService.GetResource(filter.ResourceKey + ".Required"));
            }
            if (ModelState.IsValid)
            {
                //session update
                model.Update(searchValues);

                //SearchFilters
                var fCityName = model.Filters.ElementAt(0).Value as string;
                _cityService.searchFilterLog(fCityName);

                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<City> data = _cityService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in result)
                {
                    r.Name = r.Name.ToString();
                    r.Code = r.Code.ToString();
                }
                var gridModel = new DataSourceResult
                {
                    Data = result,
                    Total = data.TotalCount
                };

                return new JsonResult
                {
                    Data = gridModel
                };
            }
            return Json(new { Errors = ModelState.SerializeErrors() });
        }

        [HttpPost]      
        public ActionResult Delete(long? parentId, long id)
        {
            var City = _cityRepository.GetById(id);

            //UseractivityLog
            string desc = City.Name + "-" + City.Code + " has been Deleted";
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);

            if (ModelState.IsValid)
            {
                //soft delete
                _cityRepository.DeactivateAndCommit(City);
                //notification
                SuccessNotification(_localizationService.GetResource("Record.Deleted"));

                return new NullJsonResult();
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }

        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Delete")]
        public ActionResult DeleteSelected(long? parentId, ICollection<long> selectedIds)
        {
            var cities = new List<City>();
            foreach (long id in selectedIds)
            {
                var city = _cityRepository.GetById(id);
                if (city != null)
                {                   
                        cities.Add(city);  
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var city in cities)
                    _cityRepository.Deactivate(city);
                    
                this._dbContext.SaveChanges();
                
                SuccessNotification(_localizationService.GetResource("Record.Deleted"));
                return new NullJsonResult();
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }

        static bool isCreate = false;

        [HttpPost]
        public ActionResult Create()
        {
            isCreate = true;
            var city = new City { IsNew = true };
           _cityRepository.InsertAndCommit(city);

            //UserActivityLog
            _cityService.Klog((city.Id),"C");
            return Json(new { Id = city.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _cityRepository.GetById(id);
            var model = attribute.ToModel();

            //UserActivityLog
            
            if (model.Name!=null) {
                _cityService.cityBeforeEditBtnLog(model.Id);
            }
          return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(CityModel model)
        {
            var attribute = _cityRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;

                _cityRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();

                //UserActivityLogs
                _cityService.cityAfterEditBtnLog(model.Id,isCreate);
                isCreate = false;
                //notification
                SuccessNotification(_localizationService.GetResource("Record.Saved"));
                return new NullJsonResult();
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }

        #endregion
    }
}