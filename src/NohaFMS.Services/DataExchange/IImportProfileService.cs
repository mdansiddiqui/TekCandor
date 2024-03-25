/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface IImportProfileService : IBaseService
    {
        PagedResult<ImportProfile> GetImportProfiles(string expression,
             dynamic parameters,
             int pageIndex = 0,
             int pageSize = 2147483647,
             IEnumerable<Sort> sort = null);
    }
}
