/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class WorkOrderTaskMap : NohaFMSEntityTypeConfiguration<WorkOrderTask>
    {
        public WorkOrderTaskMap()
            : base()
        {
            this.ToTable("WorkOrderTask");
            this.Property(e => e.SyncId).HasMaxLength(64);
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.CompletionNotes).HasMaxLength(512);
            this.Property(e => e.HoursSpent).HasPrecision(19, 4);
            this.HasOptional(e => e.WorkOrder)
                .WithMany(e => e.WorkOrderTasks)
                .HasForeignKey(e => e.WorkOrderId);
            this.HasOptional(e => e.AssignedUser)
                .WithMany()
                .HasForeignKey(e => e.AssignedUserId);
            this.HasOptional(e => e.CompletedUser)
                .WithMany()
                .HasForeignKey(e => e.CompletedUserId);
        }
    }
}
