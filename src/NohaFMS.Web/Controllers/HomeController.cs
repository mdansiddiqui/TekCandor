﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Controllers;
using System.Web.Mvc;

namespace NohaFMS.Web.Controllers
{
    public class HomeController : BaseController
    {
        protected readonly IRepository<Receipt> _receiptRepository;
        private readonly IPermissionService _permissionService;
        private readonly IWorkContext _workContext;

        public HomeController(IRepository<Receipt> receiptRepository,
            IPermissionService permissionService,
            IWorkContext workContext)
        {
            this._receiptRepository = receiptRepository;
            this._permissionService = permissionService;
            this._workContext = workContext;
        }

        // GET: Home
        public ActionResult Index()
        {
            //workflow testing
            //1.start workflow
            //var workflowServiceParameter = new WorkflowServiceParameter
            //{
            //    EntityId = 24,
            //    EntityType = EntityType.Receipt,
            //    CurrentUserId = this._workContext.CurrentUser.Id

            //};
            //var workflowInstanceId = WorkflowServiceClient.StartWorkflow(workflowServiceParameter.EntityId,
            //    workflowServiceParameter.EntityType, workflowServiceParameter.CurrentUserId);

            //2.trigger action
            //var receipt = _receiptRepository.GetById(24);
            //var workflowServiceParameter = new WorkflowServiceParameter
            //{
            //    EntityId = 24,
            //    EntityType = EntityType.Receipt,
            //    CurrentUserId = this._workContext.CurrentUser.Id,
            //    WorkflowInstanceId = receipt.Assignment.WorkflowInstanceId,
            //    WorkflowVersion = receipt.Assignment.WorkflowVersion.Value,
            //    ActionName = "Approve",
            //    Comment = "Already approved."

            //};
            //var workflowInstanceId = WorkflowServiceClient.TriggerWorkflowAction(workflowServiceParameter.EntityId,
            //    workflowServiceParameter.EntityType, workflowServiceParameter.WorkflowInstanceId, workflowServiceParameter.WorkflowVersion,
            //    workflowServiceParameter.ActionName, workflowServiceParameter.Comment, workflowServiceParameter.CurrentUserId);


            return View();
        }
    }
}