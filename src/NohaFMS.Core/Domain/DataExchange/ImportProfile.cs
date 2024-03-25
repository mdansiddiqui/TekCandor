/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System;

namespace NohaFMS.Core.Domain
{
    public class ImportProfile : BaseEntity
    {
        public int? FileTypeId { get; set; }
        public string EntityType { get; set; }

        public DateTime? LastRunStartDateTime { get; set; }
        public DateTime? LastRunEndDateTime { get; set; }

        public string ImportFileName { get; set; }
        public string LogFileName { get; set; }
    }

    public enum ImportFileType
    {
        CSV = 0,
        XLSX
    }
}
