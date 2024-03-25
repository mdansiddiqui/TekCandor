/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class ModuleMap : NohaFMSEntityTypeConfiguration<Module>
    {
        public ModuleMap()
        {
            this.ToTable("Module");
            this.Property(s => s.Description).HasMaxLength(512);
        }
    }
}
