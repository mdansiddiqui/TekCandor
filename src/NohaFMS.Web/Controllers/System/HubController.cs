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
using NohaFMS.Services.Hub;


namespace NohaFMS.Web.Controllers
{
    public class HubController : BaseController
    {
        #region Fields

        private readonly IRepository<Hub> _hubRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly ILocalizationService _localizationService;
        private readonly HttpContextBase _httpContext;
        private readonly IHubService _hubService;
        private readonly ICityService _cityService;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        #endregion

        #region Constructors

        public HubController(IRepository<Hub> hubRepository, IRepository<City> cityRepository,
                              ILocalizationService localizationService,IUserActivityService userActivityService,
                              HttpContextBase httpContext, IHubService hubService,ICityService cityService, IDbContext dbContext)
        {
            this._hubRepository = hubRepository;
            this._cityRepository = cityRepository;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._hubService = hubService;
            this._cityService = cityService;
            this._dbContext = dbContext;
            this._userActivityService = userActivityService;
        }

        #endregion

        #region Utilities
        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            var attributeNameFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "HubName",
                ResourceKey = "System.HubName",
                DbColumn = "Name",
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(attributeNameFilter);

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
          
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Hub");

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
                var fHubName = model.Filters.ElementAt(0).Value as string;
                _hubService.searchFilterLog(fHubName);
                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<Hub> data = _hubService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in result)
                {
                    r.Name = r.Name.ToString();
                    r.Code = r.Code.ToString();
                    r.CityId = r.CityId;
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
            var Hub = _hubRepository.GetById(id);
            //UseractivityLog
            string desc = Hub.Name + "-" + Hub.Code +"-"+ Hub.City+ " has been Deleted";
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);


            if (ModelState.IsValid)
            {
                //soft delete
                _hubRepository.DeactivateAndCommit(Hub);
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
            var hubs = new List<Hub>();
            foreach (long id in selectedIds)
            {
                var hub = _hubRepository.GetById(id);
                if (hub != null)
                {
                    hubs.Add(hub);
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var hub in hubs)
                    _hubRepository.Deactivate(hub);
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
            var hub = new Hub { IsNew = true };
            _hubRepository.InsertAndCommit(hub);
            //UserActivityLog
            _hubService.Klog((hub.Id), "C");
            return Json(new { Id = hub.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _hubRepository.GetById(id);
            var model = attribute.ToModel();
            //UserActivityLog
          
            if (model.Name != null)
            {
                _hubService.hubBeforeEditBtnLog(model.Id);
            }
            model.CityList = _cityRepository.GetAll().Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name });
            return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(HubModel model)
        {
            var attribute = _hubRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;

                _hubRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();
                //UserActivityLogs
                _hubService.hubAfterEditBtnLog(model.Id, isCreate);
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