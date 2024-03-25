/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AuditEntityConfigurationMap : NohaFMSEntityTypeConfiguration<AuditEntityConfiguration>
    {
        public AuditEntityConfigurationMap()
            : base()
        {
            this.ToTable("AuditEntityConfiguration");
            this.Property(s => s.EntityType).HasMaxLength(64);
            this.Property(s => s.ExcludedColumns).HasMaxLength(512);
        }
    }
}
