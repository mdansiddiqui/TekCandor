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
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NohaFMS.Web.Framework;
using System;

namespace NohaFMS.Web.Controllers
{
    public class EntityAttributeController : BaseController
    {
        #region Fields

        private readonly IRepository<EntityAttribute> _entityAttributeRepository;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Constructors

        public EntityAttributeController(IRepository<EntityAttribute> entityAttributeRepository,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            HttpContextBase httpContext,
            IWorkContext workContext,
            IDbContext dbContext)
        {
            this._entityAttributeRepository = entityAttributeRepository;
            this._localizationService = localizationService;
            this._permissionService = permissionService;
            this._httpContext = httpContext;
            this._workContext = workContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Utilities

        #endregion

        #region EntityAttribute

        [HttpPost]
        public ActionResult List(long entityId, string entityType, DataSourceRequest command, IEnumerable<Sort> sort = null)
        {
            var entityAttributes = _entityAttributeRepository.GetAll()
               .Where(a => a.EntityId == entityId && a.EntityType == entityType);
            entityAttributes = sort == null ? entityAttributes.OrderBy(a => a.DisplayOrder) : entityAttributes.Sort(sort);
            var result = entityAttributes.ToList().Select(x => x.ToModel()).ToList();
            foreach (var r in result)
            {
                r.Attribute.ControlTypeText = r.Attribute.ControlType.ToString();
                r.Attribute.DataTypeText = r.Attribute.DataType.ToString();
                r.Attribute.DataSourceText = r.Attribute.DataSource.ToString();
            }
            var gridModel = new DataSourceResult
            {
                Data = result.PagedForCommand(command),
                Total = entityAttributes.Count()
            };
            return new JsonResult
            {
                Data = gridModel
            };
        }

        [HttpPost]
        public ActionResult AddEntityAttributes(long entityId, string entityType, long[] selectedIds)
        {
            var entityAttributes = _entityAttributeRepository.GetAll().Where(e => e.EntityId == entityId && e.EntityType == entityType);
            int displayOrder = 0;
            if (entityAttributes.Count() > 0)
            {
                displayOrder = entityAttributes.Max(c => c.DisplayOrder).Value;
            }
            foreach (var id in selectedIds)
            {
                var existed = entityAttributes.Any(s => s.AttributeId == id);
                if (!existed)
                {
                    var entityAttribute = new EntityAttribute();
                    entityAttribute.EntityId = entityId;
                    entityAttribute.EntityType = entityType;
                    entityAttribute.AttributeId = id;

                    displayOrder = displayOrder + 1;
                    entityAttribute.DisplayOrder = displayOrder;
                    _entityAttributeRepository.Insert(entityAttribute);
                }
            }
            this._dbContext.SaveChanges();
            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult SaveChanges([Bind(Prefix = "updated")]List<EntityAttributeModel> updatedItems,
            [Bind(Prefix = "created")]List<EntityAttributeModel> createdItems,
            [Bind(Prefix = "deleted")]List<EntityAttributeModel> deletedItems)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //we only have update & delete
                    //Update EntityAttributes
                    if (updatedItems != null)
                    {
                        foreach (var model in updatedItems)
                        {
                            var entityAttribute = _entityAttributeRepository.GetById(model.Id);
                            entityAttribute.DisplayOrder = model.DisplayOrder;
                            entityAttribute.IsRequiredField = model.IsRequiredField;
                            _entityAttributeRepository.Update(entityAttribute);
                        }
                    }

                    //Delete EntityAttributes
                    if (deletedItems != null)
                    {
                        foreach (var model in deletedItems)
                        {
                            var entityAttribute = _entityAttributeRepository.GetById(model.Id);
                            if (entityAttribute != null)
                            {
                                _entityAttributeRepository.Deactivate(entityAttribute);
                            }
                        }
                    }

                    _dbContext.SaveChanges();
                    SuccessNotification(_localizationService.GetResource("Record.Saved"));
                    return new NullJsonResult();
                }
                catch (Exception e)
                {
                    return Json(new { Errors = e.Message });
                }
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }
        #endregion
    }
}