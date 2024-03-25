/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class AutoNumber : BaseEntity
    {
        public string EntityType { get; set; }
        public string FormatString { get; set; }
        public int LastNumber { get; set; }
    }
}
