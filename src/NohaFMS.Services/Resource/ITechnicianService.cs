/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using System;
using System.Collections.Generic;

namespace NohaFMS.Services
{
    public interface ITechnicianService : IBaseService
    {
        PagedResult<Technician> GetTechnicians(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<Technician> GetTechnicians(long? teamId, int? technicianMatching, DateTime? dateTime, string param);
        void ResourceActivityFlowlog(long id, string description);

    }
}
