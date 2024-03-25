
using System.Web.Mvc;
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using NohaFMS.Services;
//using NohaFMS.Web.Extensions;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Framework.CustomField;
using NohaFMS.Web.Framework.Session;
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NohaFMS.Services.ReturnReason;
using NohaFMS.Web.Extensions;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Framework.Filters;

namespace NohaFMS.Web.Controllers.System
{
    public class ReturnReasonController : BaseController
    {
        #region Fields

        private readonly IRepository<ReturnReason> _returnReasonRepository;
        private readonly ILocalizationService _localizationService;
        private readonly HttpContextBase _httpContext;
        private readonly IReturnReasonService _returnReasonService;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        #endregion
        #region Constructors

        public ReturnReasonController(IRepository<ReturnReason> returnReasonRepository,
        ILocalizationService localizationService, IUserActivityService userActivityService,
                              HttpContextBase httpContext, IReturnReasonService returnReasonService,
                              IDbContext dbContext)
        {
            this._returnReasonRepository = returnReasonRepository;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._userActivityService = userActivityService;
            this._returnReasonService = returnReasonService;
            this._dbContext = dbContext;
        }

        #endregion

        #region Utilities
        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            var attributeCodeFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "AlphaReturnCodes",
                ResourceKey = "System.AlphaReturnCodes",
                DbColumn = "AlphaReturnCodes",
          
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(attributeCodeFilter);
            var attributeNIFTCodeFilter = new FieldModel
            {
                DisplayOrder = 2,
                Name = "NumericReturnCodes",
                ResourceKey = "System.NumericReturnCodes",
                DbColumn = "NumericReturnCodes",
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(attributeNIFTCodeFilter);



            return model;
        }
        #endregion


        // GET: ReturnReason
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
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "ReturnReason");
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
                var fReturnReasonName = model.Filters.ElementAt(0).Value as string;
                _returnReasonService.searchFilterLog(fReturnReasonName);

                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<ReturnReason> data = _returnReasonService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in result)
                {

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
            var ReturnReason = _returnReasonRepository.GetById(id);
            string desc = ReturnReason.Name + "-" + " has been Deleted";
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);
            if (ModelState.IsValid)
            {
                //soft delete
                _returnReasonRepository.DeactivateAndCommit(ReturnReason);
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
            var returnReasons = new List<ReturnReason>();
            foreach (long id in selectedIds)
            {
                var returnReason = _returnReasonRepository.GetById(id);
                if (returnReason != null)
                {
                    returnReasons.Add(returnReason);
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var returnReason in returnReasons)
                    _returnReasonRepository.Deactivate(returnReason);
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
            var returnReason = new ReturnReason { IsNew = true };
            _returnReasonRepository.InsertAndCommit(returnReason);
            //    _returnReasonService.Klog(returnReason.Id, "C");

            return Json(new { Id = returnReason.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _returnReasonRepository.GetById(id);
            var model = attribute.ToModel();
            //UserActivityLog
            if (model.Name != null)
            {
                _returnReasonService.returnReasonBeforeEditBtnLog(model.Id);
            }
            //model.HubList = _hubRepository.GetAll().Select(u => new SelectListItem { Value = u.Id.ToString(), Text = u.Name });
            return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(ReturnReasonModel model)
        {
            var attribute = _returnReasonRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;

                _returnReasonRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();
                //UserActivityLogs
                _returnReasonService.returnReasonAfterEditBtnLog(model.Id, isCreate);
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






























    }
}