﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Web.Framework.Mvc
{
    public class DeleteConfirmationModel : BaseEamEntityModel
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string WindowId { get; set; }
    }
}