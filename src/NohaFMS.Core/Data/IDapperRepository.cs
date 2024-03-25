/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Data
{
    public interface IDapperRepository<T> where T : BaseEntity
    {
        T GetById(long id);
        IEnumerable<T> Query(string sql, object param = null);
        IEnumerable<T> GetAll(bool showIsDeleted = false);
        long Insert(T entity);
        int Insert(IEnumerable<T> entities);
        bool Update(T entity);
        bool Update(IEnumerable<T> entities);
        bool Delete(T entity);
        bool Delete(IEnumerable<T> entities);
        bool DeleteAll();
    }
}
