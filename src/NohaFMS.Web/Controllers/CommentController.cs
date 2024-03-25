/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Services;
using NohaFMS.Web.Extensions;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Models;
using System.Web.Mvc;

namespace NohaFMS.Web.Controllers
{
    public class CommentController : BaseController
    {
        private readonly IRepository<Comment> _commentRepository;
        private readonly ILocalizationService _localizationService;

        public CommentController(IRepository<Comment> commentRepository,
            ILocalizationService localizationService)
        {
            this._commentRepository = commentRepository;
            this._localizationService = localizationService;
        }

        [HttpPost]
        public ActionResult Create(CommentModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = model.ToEntity();
                comment.IsNew = false;
                _commentRepository.InsertAndCommit(comment);

                //notification
                SuccessNotification(_localizationService.GetResource("Record.Saved"));
                return Json(new { Html = this.RenderPartialViewToString("CommentBox", comment) });
            }
            else
            {
                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }

        [HttpGet]
        public ActionResult AddCommentView()
        {
            return PartialView("_AddCommentView", new CommentModel());
        }
    }
}