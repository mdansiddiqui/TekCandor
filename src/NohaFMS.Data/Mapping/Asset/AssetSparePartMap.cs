/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AssetSparePartMap : NohaFMSEntityTypeConfiguration<AssetSparePart>
    {
        public AssetSparePartMap()
            : base()
        {
            this.ToTable("AssetSparePart");
            this.HasOptional(e => e.Asset)
                .WithMany(e => e.AssetSpareParts)
                .HasForeignKey(e => e.AssetId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
            this.Property(e => e.Quantity).HasPrecision(19, 4);
        }
    }
}
