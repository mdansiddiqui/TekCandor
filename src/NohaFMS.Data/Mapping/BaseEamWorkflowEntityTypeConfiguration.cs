/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public abstract class NohaFMSWorkflowEntityTypeConfiguration<T> : NohaFMSEntityTypeConfiguration<T> where T : WorkflowBaseEntity
    {
        protected NohaFMSWorkflowEntityTypeConfiguration()
            : base()
        {
            this.Property(e => e.Number).HasMaxLength(64);
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Assignment)
                .WithMany()
                .HasForeignKey(e => e.AssignmentId)
                .WillCascadeOnDelete(true);
        }
    }
}
