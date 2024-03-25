/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ServiceRequestMap : NohaFMSWorkflowEntityTypeConfiguration<ServiceRequest>
    {
        public ServiceRequestMap()
        {
            this.ToTable("ServiceRequest");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Site)
                .WithMany()
                .HasForeignKey(e => e.SiteId);
            this.HasOptional(e => e.Asset)
                .WithMany()
                .HasForeignKey(e => e.AssetId);
            this.HasOptional(e => e.Location)
                .WithMany()
                .HasForeignKey(e => e.LocationId);
            this.Property(e => e.RequestorName).HasMaxLength(64);
            this.Property(e => e.RequestorEmail).HasMaxLength(64);
            this.Property(e => e.RequestorPhone).HasMaxLength(64);
        }
    }
}
