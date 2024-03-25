/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class Attribute : BaseEntity
    {
        public string ResourceKey { get; set; }
        public int? ControlType { get; set; }
        public int? DataType { get; set; }
        public int? DataSource { get; set; }
        /// <summary>
        /// Specify values when data source = CSV
        /// not including empty value
        /// </summary>
        public string CsvTextList { get; set; }
        public string CsvValueList { get; set; }
    }
}
