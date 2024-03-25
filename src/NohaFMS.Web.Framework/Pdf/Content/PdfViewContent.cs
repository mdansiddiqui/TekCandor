/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Web.Mvc;
using NohaFMS.Services.Pdf;
using NohaFMS.Web.Framework.Controllers;

namespace NohaFMS.Web.Framework.Pdf
{

    public class PdfViewContent : PdfHtmlContent
    {

        public PdfViewContent(string viewName, object model, ControllerContext controllerContext)
            : this(viewName, null, model, controllerContext)
        {
        }

        public PdfViewContent(string viewName, string masterName, object model, ControllerContext controllerContext)
            : base(ViewToString(viewName, masterName, model, false, controllerContext, true))
        {
        }

        protected internal static string ViewToString(string viewName, string masterName, object model, bool isPartial, ControllerContext context, bool throwOnError)
        {
            string html = null;

            try
            {
                html = isPartial
                    ? context.Controller.RenderPartialViewToString(viewName, model)
                    : context.Controller.RenderViewToString(viewName, masterName, model);
            }
            catch (Exception)
            {
                if (throwOnError)
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }

            return html;
        }
    }

}
