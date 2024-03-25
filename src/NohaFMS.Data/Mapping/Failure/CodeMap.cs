/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CodeMap : NohaFMSEntityTypeConfiguration<Code>
    {
        public CodeMap()
            : base()
        {
            this.ToTable("Code");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.HierarchyIdPath).HasMaxLength(64);
            this.Property(e => e.CodeType).HasMaxLength(64);
            this.Property(e => e.HierarchyNamePath).HasMaxLength(512);
            this.HasOptional(e => e.Parent)
                .WithMany(e => e.Children)
                .HasForeignKey(e => e.ParentId);
        }
    }
}
