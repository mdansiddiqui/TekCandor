/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PMTaskMap : NohaFMSEntityTypeConfiguration<PMTask>
    {
        public PMTaskMap()
            : base()
        {
            this.ToTable("PMTask");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.PreventiveMaintenance)
                .WithMany(e => e.PMTasks)
                .HasForeignKey(e => e.PreventiveMaintenanceId);
            this.HasOptional(e => e.AssignedUser)
                .WithMany()
                .HasForeignKey(e => e.AssignedUserId);
        }
    }
}
