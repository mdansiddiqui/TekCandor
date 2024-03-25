/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Web.Mvc;
using NohaFMS.Services.Pdf;

namespace NohaFMS.Web.Framework.Pdf
{

    public class PdfPartialViewContent : PdfHtmlContent
    {
        public PdfPartialViewContent(string partialViewName, object model, ControllerContext controllerContext)
            : base(PdfViewContent.ViewToString(partialViewName, null, model, true, controllerContext, false))
        {
        }
    }

}
