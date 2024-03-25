/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public class EntityAttachment : BaseEntity
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }

        public long? AttachmentId { get; set; }
        public virtual Attachment Attachment { get; set; }
    }
}
