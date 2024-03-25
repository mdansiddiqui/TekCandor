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
using NohaFMS.Services.Branch;
using NohaFMS.Services.Hub;

namespace NohaFMS.Web.Controllers
{
    public class BranchController : BaseController
    {
        #region Fields

        private readonly IRepository<Branch> _branchRepository;
        private readonly IRepository<Hub> _hubRepository;
        private readonly ILocalizationService _localizationService;
        private readonly HttpContextBase _httpContext;
        private readonly IBranchService _branchService;
        private readonly IHubService _hubService;
        private readonly IDbContext _dbContext;
        private readonly IUserActivityService _userActivityService;
        #endregion

        #region Constructors

        public BranchController(IRepository<Branch> branchRepository, IRepository<Hub> hubRepository,
        ILocalizationService localizationService,IUserActivityService userActivityService,
                              HttpContextBase httpContext, IBranchService branchService, IHubService hubService, IDbContext dbContext)
        {
            this._branchRepository = branchRepository;
            this._hubRepository = hubRepository;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._userActivityService = userActivityService;
            this._branchService = branchService;
            this._hubService = hubService;
            this._dbContext = dbContext;
        }

        #endregion

        #region Utilities
        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            var attributeNameFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "BranchName",
                ResourceKey = "System.BranchName",
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
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Branch");
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
                var fBranchName = model.Filters.ElementAt(0).Value as string;
                _branchService.searchFilterLog(fBranchName);

                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<Branch> data = _branchService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
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
            var Branch = _branchRepository.GetById(id);
            string desc = Branch.Name+"-"+Branch.Code +" has been Deleted";
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);
            if (ModelState.IsValid)
            {
                //soft delete
                _branchRepository.DeactivateAndCommit(Branch);
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
            var branches = new List<Branch>();
            foreach (long id in selectedIds)
            {
                var branch = _branchRepository.GetById(id);
                if (branch != null)
                {
                    branches.Add(branch);
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var branch in branches)
                    _branchRepository.Deactivate(branch);
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
            var branch = new Branch { IsNew = true };
            _branchRepository.InsertAndCommit(branch);
            _branchService.Klog(branch.Id, "C");

            return Json(new { Id = branch.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _branchRepository.GetById(id);
            var model = attribute.ToModel();
            //UserActivityLog
            if (model.Name != null)
            {
                _branchService.branchBeforeEditBtnLog(model.Id);
            }
            model.HubList = _hubRepository.GetAll().Select(u=> new SelectListItem { Value = u.Id.ToString() , Text = u.Name });
            return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(BranchModel model)
        {
            var attribute = _branchRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;
                
                _branchRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();
                //UserActivityLogs
                _branchService.branchAfterEditBtnLog(model.Id,isCreate);
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