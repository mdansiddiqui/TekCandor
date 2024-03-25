/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public partial class LogMap : NohaFMSEntityTypeConfiguration<Log>
    {
        public LogMap()
        {
            this.ToTable("Log");
            this.Property(l => l.ShortMessage).IsRequired();
            this.Ignore(l => l.LogLevel);
            this.HasOptional(l => l.User)
                .WithMany()
                .HasForeignKey(l => l.UserId)
                .WillCascadeOnDelete(true);
        }
    }
}