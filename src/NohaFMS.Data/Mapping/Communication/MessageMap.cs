/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MessageMap : NohaFMSEntityTypeConfiguration<Message>
    {
        public MessageMap()
        {
            this.ToTable("Message");
            this.Property(s => s.Sender).HasMaxLength(128);
            this.Property(s => s.AttachmentIds).HasMaxLength(256);
        }
    }
}
