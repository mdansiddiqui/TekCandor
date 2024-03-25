/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MessageTemplateMap : NohaFMSEntityTypeConfiguration<MessageTemplate>
    {
        public MessageTemplateMap()
        {
            this.ToTable("MessageTemplate");
            this.Property(s => s.Description).HasMaxLength(512);
            this.Property(s => s.EntityType).HasMaxLength(64);
            this.Property(s => s.PushTemplate).HasMaxLength(512);
            this.Property(s => s.SMSTemplate).HasMaxLength(128);
            this.Property(s => s.EmailSubjectTemplate).HasMaxLength(512);
            this.Property(s => s.EmailSender).HasMaxLength(128);
        }
    }
}
