/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class Script : BaseEntity
    {
        public string Description { get; set; }
        public string Type { get; set; }
        public string SourceCode { get; set; }
    }
}
