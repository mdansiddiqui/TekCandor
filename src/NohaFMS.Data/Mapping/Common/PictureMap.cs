/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PictureMap : NohaFMSEntityTypeConfiguration<Picture>
    {
        public PictureMap()
            :base()
        {
            this.ToTable("Picture");
            this.Property(a => a.Extension).HasMaxLength(64);
            this.Property(a => a.EntityType).HasMaxLength(64);
            this.Property(a => a.ContentType).HasMaxLength(64);
        }
    }
}
