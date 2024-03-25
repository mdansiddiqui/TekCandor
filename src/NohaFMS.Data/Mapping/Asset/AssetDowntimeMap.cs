/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AssetDowntimeMap : NohaFMSEntityTypeConfiguration<AssetDowntime>
    {
        public AssetDowntimeMap()
            : base()
        {
            this.ToTable("AssetDowntime");
            this.HasOptional(e => e.Asset)
                .WithMany(e => e.AssetDowntimes)
                .HasForeignKey(e => e.AssetId);
            this.HasOptional(e => e.DowntimeType)
                .WithMany()
                .HasForeignKey(e => e.DowntimeTypeId);
            this.HasOptional(e => e.ReportedUser)
                .WithMany()
                .HasForeignKey(e => e.ReportedUserId);
        }
    }
}
