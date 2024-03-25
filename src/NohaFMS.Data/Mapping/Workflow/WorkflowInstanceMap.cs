/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Domain;
using System.Data.Entity.ModelConfiguration;

namespace NohaFMS.Data.Mapping
{
    public class WorkflowInstanceMap : NohaFMSEntityTypeConfiguration<WorkflowInstance>
    {
        public WorkflowInstanceMap()
            : base()
        {
            this.ToTable("WorkflowInstance");
            this.Property(e => e.InstanceId).HasMaxLength(64);
        }
    }
}
