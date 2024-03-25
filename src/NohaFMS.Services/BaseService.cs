/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;

namespace NohaFMS.Services
{
    /// <summary>
    /// BaseService includes services common to BaseEntity
    /// </summary>
    public partial class BaseService : IBaseService
    {
        /// <summary>
        /// Use for an aggregate. The rule will be detemined by entity type
        /// Ex: If(typeof(entity) == "StoreCheckIn") { ... } else if (typeof(entity) == "StoreCheckInItem") { ... }
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public virtual bool IsDeactivable(BaseEntity entity)
        {
            return true;
        }

        /// <summary>
        /// Use for an aggregate. The rule will be detemined by entity type
        /// Ex: If(typeof(entity) == "StoreCheckIn") { ... } else if (typeof(entity) == "StoreCheckInItem") { ... }
        /// If deactivate for only one entity, should use repo.Deactivate()
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Deactivate(BaseEntity entity)
        {
            entity.IsDeleted = true;
        }

        /// <summary>
        /// Use for an aggregate. The rule will be detemined by entity type
        /// Ex: If(typeof(entity) == "StoreCheckIn") { ... } else if (typeof(entity) == "StoreCheckInItem") { ... }
        /// If activate for only one entity, should use repo.Activate()
        /// </summary>
        /// <param name="entity"></param>
        public virtual void Activate(BaseEntity entity)
        {
            entity.IsDeleted = false;
        }
    }
}
