/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using System;

namespace NohaFMS.Web.Models
{
    public class AuditTrailModel
    {
        public long Id { get; set; }

        [BaseEamResourceDisplayName("AuditLog.UserName")]
        public string UserName { get; set; }

        [BaseEamResourceDisplayName("AuditTrail.Date")]
        public DateTime Date { get; set; }
    }
}