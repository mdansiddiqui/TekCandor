/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class SettingMap : NohaFMSEntityTypeConfiguration<Setting>
    {
        public SettingMap()
        {
            this.ToTable("Setting");
            this.Property(s => s.Name).IsRequired().HasMaxLength(256);
            this.Property(s => s.Value).IsRequired().HasMaxLength(2048);
        }
    }
}