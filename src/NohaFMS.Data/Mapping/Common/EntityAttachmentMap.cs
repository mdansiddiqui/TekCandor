/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class EntityAttachmentMap : NohaFMSEntityTypeConfiguration<EntityAttachment>
    {
        public EntityAttachmentMap()
        {
            this.ToTable("EntityAttachment");
            this.Property(s => s.EntityType).HasMaxLength(64);
            this.HasOptional(e => e.Attachment)
                .WithMany(e => e.EntityAttachments)
                .HasForeignKey(e => e.AttachmentId)
                .WillCascadeOnDelete(true);
        }
    }
}
