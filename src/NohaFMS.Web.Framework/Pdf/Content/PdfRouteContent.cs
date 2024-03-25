/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Web.Mvc;
using System.Web.Routing;
using NohaFMS.Services.Pdf;

namespace NohaFMS.Web.Framework.Pdf
{

    public class PdfRouteContent : PdfUrlContent
    {
        public PdfRouteContent(string routeName, ControllerContext controllerContext)
            : this(routeName, null, null, null, controllerContext)
        {
        }

        public PdfRouteContent(string routeName, RouteValueDictionary routeValues, ControllerContext controllerContext)
            : this(routeName, null, null, routeValues, controllerContext)
        {
        }

        public PdfRouteContent(string action, string controller, ControllerContext controllerContext)
            : this(null, action, controller, null, controllerContext)
        {
        }

        public PdfRouteContent(string action, string controller, RouteValueDictionary routeValues, ControllerContext controllerContext)
            : this(null, action, controller, routeValues, controllerContext)
        {
        }

        protected PdfRouteContent(string routeName, string action, string controller, RouteValueDictionary routeValues, ControllerContext controllerContext)
            : base(UrlHelper.GenerateUrl(routeName, action, controller, routeValues, RouteTable.Routes, controllerContext.RequestContext, true))
        {
        }
    }
}
