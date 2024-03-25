/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using System;
using System.Web.Mvc;

namespace NohaFMS.Web.Models
{
    public class LogModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Log.LogLevel")]
        public string LogLevel { get; set; }

        [BaseEamResourceDisplayName("Log.ShortMessage")]
        [AllowHtml]
        public string ShortMessage { get; set; }

        [BaseEamResourceDisplayName("Log.FullMessage")]
        [AllowHtml]
        public string FullMessage { get; set; }

        [BaseEamResourceDisplayName("Log.User")]
        public long? UserId { get; set; }

        public UserModel User { get; set; }

        public string UserEmail { get; set; }

        [BaseEamResourceDisplayName("Log.CreatedOn")]
        public DateTime CreatedOn { get; set; }
    }
}