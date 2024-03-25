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
    public interface ILocationService : IBaseService
    {
        PagedResult<Location> GetLocations(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<Location> GetSiteLocationList(long parentValue, string param);

        List<Location> GetAllLocationsByParentId(long? parentId);
        
        void AssetActivityFlowlog(long id, string description);

    }
}
