/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class WorkflowDefinitionVersionMap : NohaFMSEntityTypeConfiguration<WorkflowDefinitionVersion>
    {
        public WorkflowDefinitionVersionMap()
            : base()
        {
            this.ToTable("WorkflowDefinitionVersion");
            this.Property(e => e.WorkflowXamlFileName).HasMaxLength(64);
            this.Property(e => e.WorkflowPictureFileName).HasMaxLength(64);
            this.HasOptional(e => e.WorkflowDefinition)
                .WithMany(e => e.WorkflowDefinitionVersions)
                .HasForeignKey(e => e.WorkflowDefinitionId)
                .WillCascadeOnDelete(true);
        }
    }
}
