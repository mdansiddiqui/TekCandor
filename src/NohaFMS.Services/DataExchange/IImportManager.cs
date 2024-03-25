/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

using NohaFMS.Core.Domain;

namespace NohaFMS.Services
{
    public interface IImportManager
    {
        void Execute(long importProfileId);

        #region UnitOfMeasure

        void ImportUnitOfMeasureFromXlsx(ImportProfile importProfile);

        #endregion
    }
}
