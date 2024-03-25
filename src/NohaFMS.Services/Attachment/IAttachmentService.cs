/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Services
{
    public interface IAttachmentService : IBaseService
    {
        void CopyAttachments(long fromEntityId, string fromEntityType, long toEntityId, string toEntityType);
    }
}
