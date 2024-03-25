/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AssetStatusHistoryMap : NohaFMSEntityTypeConfiguration<AssetStatusHistory>
    {
        public AssetStatusHistoryMap()
            : base()
        {
            this.ToTable("AssetStatusHistory");
            this.HasOptional(e => e.Asset)
                .WithMany(e => e.AssetStatusHistories)
                .HasForeignKey(e => e.AssetId);
            this.HasOptional(e => e.ChangedUser)
                .WithMany()
                .HasForeignKey(e => e.ChangedUserId);
            this.Property(e => e.FromStatus).HasMaxLength(64);
            this.Property(e => e.ToStatus).HasMaxLength(64);
        }
    }
}
