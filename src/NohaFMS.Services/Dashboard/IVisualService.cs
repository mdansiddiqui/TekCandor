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
    public interface IVisualService : IBaseService
    {
        PagedResult<Visual> GetVisuals(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null); //Int32.MaxValue

        List<Visual> GetVisualsByUser(User user);

        IEnumerable<dynamic> GetVisualData(Visual visual,
            string expression,
            dynamic parameters,
            IEnumerable<Sort> sort = null);

        void VisualActivityFlowlog(long id, string description);
        void ReportActivityFlowlog(long id, string description);
        void searchFilterLog(string fVisual);
    }
}
