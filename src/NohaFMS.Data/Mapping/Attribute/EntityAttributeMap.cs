/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class EntityAttributeMap : NohaFMSEntityTypeConfiguration<EntityAttribute>
    {
        public EntityAttributeMap()
        {
            this.ToTable("EntityAttribute");
            this.Property(s => s.EntityType).HasMaxLength(64);
            this.Property(s => s.Value).HasMaxLength(256);
            this.HasOptional(e => e.Attribute)
                .WithMany()
                .HasForeignKey(e => e.AttributeId);
        }
    }
}
