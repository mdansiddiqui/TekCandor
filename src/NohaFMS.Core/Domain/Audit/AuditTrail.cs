/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class AuditTrail : BaseEntity
    {
        public DateTime Date { get; set; }
        public string LogXml { get; set; }
    }
}
