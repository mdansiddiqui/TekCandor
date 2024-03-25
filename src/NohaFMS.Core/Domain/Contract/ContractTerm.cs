/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class ContractTerm : BaseEntity
    {
        public int? Sequence { get; set; }
        public string Description { get; set; }

        public long? ContractId { get; set; }
        public virtual Contract Contract { get; set; }
    }
}
