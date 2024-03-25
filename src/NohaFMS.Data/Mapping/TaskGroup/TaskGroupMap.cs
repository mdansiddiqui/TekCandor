/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class TaskGroupMap : NohaFMSEntityTypeConfiguration<TaskGroup>
    {
        public TaskGroupMap()
            : base()
        {
            this.ToTable("TaskGroup");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.AssetTypes).HasMaxLength(512);
        }
    }
}
