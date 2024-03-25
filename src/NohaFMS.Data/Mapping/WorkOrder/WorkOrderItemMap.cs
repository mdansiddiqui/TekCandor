/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class WorkOrderItemMap : NohaFMSEntityTypeConfiguration<WorkOrderItem>
    {
        public WorkOrderItemMap()
            : base()
        {
            this.ToTable("WorkOrderItem");
            this.Property(e => e.SyncId).HasMaxLength(64);
            this.HasOptional(e => e.WorkOrder)
                .WithMany(e => e.WorkOrderItems)
                .HasForeignKey(e => e.WorkOrderId);
            this.HasOptional(e => e.Store)
                .WithMany()
                .HasForeignKey(e => e.StoreId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
            this.HasOptional(e => e.StoreLocator)
                .WithMany()
                .HasForeignKey(e => e.StoreLocatorId);
            this.Property(e => e.UnitPrice).HasPrecision(19, 4);
            this.Property(e => e.PlanQuantity).HasPrecision(19, 4);
            this.Property(e => e.PlanTotal).HasPrecision(19, 4);
            this.Property(e => e.ActualQuantity).HasPrecision(19, 4);
            this.Property(e => e.ActualTotal).HasPrecision(19, 4);

            this.Property(e => e.PlanToolHours).HasPrecision(19, 4);
            this.Property(e => e.ToolRate).HasPrecision(19, 4);
            this.Property(e => e.ActualToolHours).HasPrecision(19, 4);
        }
    }
}
