/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Services
{
    public interface IEntityAttributeService : IBaseService
    {
        void UpdateEntityAttributes(long? entityId, string entityType, string json);
    }
}
