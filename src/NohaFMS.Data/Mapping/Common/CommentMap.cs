/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CommentMap : NohaFMSEntityTypeConfiguration<Comment>
    {
        public CommentMap()
            :base()
        {
            this.ToTable("Comment");
            this.Property(a => a.EntityType).HasMaxLength(64);
            this.Property(a => a.Message).HasMaxLength(512);
        }
    }
}
