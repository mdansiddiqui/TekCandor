/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using System.Data.Entity.ModelConfiguration;

namespace NohaFMS.Data.Mapping
{
    public abstract class NohaFMSEntityTypeConfiguration<T> : EntityTypeConfiguration<T> where T : BaseEntity
    {
        protected NohaFMSEntityTypeConfiguration()
        {
            this.HasKey(e => e.Id);
            this.Property(e => e.Name).HasMaxLength(256);
            this.Property(e => e.CreatedUser).HasMaxLength(128);
            this.Property(e => e.ModifiedUser).HasMaxLength(128);
            this.Property(e => e.Version).IsConcurrencyToken();
            //this.Property(e => e.RowVersion).IsRowVersion();
        }
    }
}
