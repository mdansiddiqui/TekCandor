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
using NohaFMS.Services.PasswordPolicy;

namespace NohaFMS.Web.Controllers
{
    public class PasswordPolicyController : BaseController
    {
        #region Fields

        private readonly IRepository<PasswordPolicy> _passwordPolicyRepository;
        private readonly ILocalizationService _localizationService;
        private readonly HttpContextBase _httpContext;
        private readonly IPasswordPolicyService _passwordPolicyService;
        private readonly IDbContext _dbContext;
        #endregion

        #region Constructors

        public PasswordPolicyController(IRepository<PasswordPolicy> passwordPolicyRepository,
                              ILocalizationService localizationService,
                              HttpContextBase httpContext, IPasswordPolicyService passwordPolicyService, IDbContext dbContext)
        {
            this._passwordPolicyRepository = passwordPolicyRepository;
            this._localizationService = localizationService;
            this._httpContext = httpContext;
            this._passwordPolicyService = passwordPolicyService;
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
                Name = "Name",
                ResourceKey = "System.PolicyName",
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
                _httpContext.Session[SessionKey.AttributeSearchModel] = model;

                PagedResult<PasswordPolicy> data = _passwordPolicyService.GetAttributes(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in result)
                {
                    r.Name = r.Name.ToString();
                    r.NameOther = r.NameOther.ToString();
                    r.Description = r.Description.ToString();
                    r.CountHistory = r.CountHistory;
                    r.ExpiryDays = r.CountHistory;
                    r.NotifyDays = r.CountHistory;
                    r.AccountDisableDays = r.CountHistory;
                    r.InvalidLoginEntry = r.CountHistory;
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
            var PasswordPolicy = _passwordPolicyRepository.GetById(id);

            if (ModelState.IsValid)
            {
                //soft delete
                _passwordPolicyRepository.DeactivateAndCommit(PasswordPolicy);
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
            var passs = new List<PasswordPolicy>();
            foreach (long id in selectedIds)
            {
                var passwordPolicy = _passwordPolicyRepository.GetById(id);
                if (passwordPolicy != null)
                {
                    passs.Add(passwordPolicy);
                }
            }
            if (ModelState.IsValid)
            {
                foreach (var passwordPolicy in passs)
                    _passwordPolicyRepository.Deactivate(passwordPolicy);
                this._dbContext.SaveChanges();
                SuccessNotification(_localizationService.GetResource("Record.Deleted"));
                return new NullJsonResult();
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }


        [HttpPost]
        public ActionResult Create()
        {
            var passwordPolicy = new PasswordPolicy { IsNew = true };
            _passwordPolicyRepository.InsertAndCommit(passwordPolicy);
            return Json(new { Id = passwordPolicy.Id });
        }



        public ActionResult Edit(long id)
        {
            var attribute = _passwordPolicyRepository.GetById(id);
            var model = attribute.ToModel();

            return View(model);
        }


        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "System.Attribute.Create,System.Attribute.Update")]
        public ActionResult Edit(PasswordPolicyModel model)
        {
            var attribute = _passwordPolicyRepository.GetById(model.Id);
            if (ModelState.IsValid)
            {
                attribute = model.ToEntity(attribute);
                //always set IsNew to false when saving
                attribute.IsNew = false;

                _passwordPolicyRepository.Update(attribute);

                //commit all changes
                this._dbContext.SaveChanges();

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