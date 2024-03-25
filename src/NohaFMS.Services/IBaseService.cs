/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;

namespace NohaFMS.Services
{
    public partial interface IBaseService
    {
        bool IsDeactivable(BaseEntity entity);
        void Deactivate(BaseEntity entity);
        void Activate(BaseEntity entity);
    }
}
