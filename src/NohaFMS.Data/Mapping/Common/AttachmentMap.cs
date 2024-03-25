/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AttachmentMap : NohaFMSEntityTypeConfiguration<Attachment>
    {
        public AttachmentMap()
            :base()
        {
            this.ToTable("Attachment");
            this.Property(a => a.Extension).HasMaxLength(64);
            this.Property(a => a.ContentType).HasMaxLength(64);
        }
    }
}
