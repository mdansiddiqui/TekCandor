/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AssignmentGroupMap : NohaFMSEntityTypeConfiguration<AssignmentGroup>
    {
        public AssignmentGroupMap()
        {
            this.ToTable("AssignmentGroup");
            this.Property(s => s.Description).HasMaxLength(512);
        }
    }
}
