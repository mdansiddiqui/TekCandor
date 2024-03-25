/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class WorkflowDefinitionMap : NohaFMSEntityTypeConfiguration<WorkflowDefinition>
    {
        public WorkflowDefinitionMap()
            : base()
        {
            this.ToTable("WorkflowDefinition");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.EntityType).HasMaxLength(64);
        }
    }
}
