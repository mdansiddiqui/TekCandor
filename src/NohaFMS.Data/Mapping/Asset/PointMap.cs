/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class PointMap : NohaFMSEntityTypeConfiguration<Point>
    {
        public PointMap()
            : base()
        {
            this.ToTable("Point");
            this.HasOptional(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId);
            this.HasOptional(e => e.Asset)
                .WithMany()
                .HasForeignKey(e => e.AssetId);
            this.HasOptional(e => e.MeterGroup)
                .WithMany()
                .HasForeignKey(e => e.MeterGroupId);            
        }
    }
}
