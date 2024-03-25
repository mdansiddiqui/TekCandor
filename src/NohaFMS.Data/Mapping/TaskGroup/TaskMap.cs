/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Data.Mapping
{
    public class TaskMap : NohaFMSEntityTypeConfiguration<Core.Domain.Task>
    {
        public TaskMap()
            : base()
        {
            this.ToTable("Task");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.TaskGroup)
                .WithMany(e => e.Tasks)
                .HasForeignKey(e => e.TaskGroupId);
        }
    }
}
