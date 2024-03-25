﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ScriptMap : NohaFMSEntityTypeConfiguration<Script>
    {
        public ScriptMap()
            : base()
        {
            this.ToTable("Script");
            this.Property(e => e.Description).HasMaxLength(512);
            this.Property(e => e.Type).HasMaxLength(64);
        }
    }
}
