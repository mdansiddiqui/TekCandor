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
using NohaFMS.Services.Cycle;

namespace NohaFMS.Web.Controllers
{
    public class CycleController : BaseController
    {
        #region Fields

        private readonly IRepository<Cycle> _cycleRepository;
        private readonly ILocalizationService _localizationService;
        private readonly HttpContextBase _httpContext;
        private readonly ICycleService _cycleService;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        #endregion

        #region Constructors

        public CycleController(IRepository<Cycle> cycleRepository,
                              ILocalizationService localizationService,
                              HttpContextBase httpContext, ICycleService cycleService, IDbContext dbContext,
                              IUserActivityService userActivityService)
        {
            this._cycleRepository = cycleRepository;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._cycleService = cycleService;
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
                Name = "CycleName",
                ResourceKey = "System.CycleName",
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
        {//UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Cycle");

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
                var fCycleName = model.Filters.ElementAt(0).Value as string;
                _cycleService.searchFilterLog(fCycleName);
                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<Cycle> data = _cycleService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in result)
                {
                    r.Name = r.Name.ToString();
                    r.Code = r.Code;
                    r.Description = r.Description;
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
            var Cycle = _cycleRepository.GetById(id);
            //UseractivityLog
            string desc = Cycle.Name + "-" + Cycle.Description + " has been Deleted";
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);

            if (ModelState.IsValid)
            {
                //soft delete
                _cycleRepository.DeactivateAndCommit(Cycle);
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
            var cities = new List<Cycle>();
            foreach (long id in selectedIds)
            {
                var cycle = _cycleRepository.GetById(id);
                if (cycle != null)
                {
                    cities.Add(cycle);
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var cycle in cities)
                    _cycleRepository.Deactivate(cycle);
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
            var cycle = new Cycle { IsNew = true };
            _cycleRepository.InsertAndCommit(cycle);
            _cycleService.Klog((cycle.Id), "C");
            return Json(new { Id = cycle.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _cycleRepository.GetById(id);
            var model = attribute.ToModel();
            //UserActivityLog

            if (model.Name != null)
            {
                _cycleService.cycleBeforeEditBtnLog(model.Id);
            }
            return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(CycleModel model)
        {
            var attribute = _cycleRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;

                _cycleRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();
                //UserActivityLogs
                _cycleService.cycleAfterEditBtnLog(model.Id, isCreate);
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