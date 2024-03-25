/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReturnItemMap : NohaFMSEntityTypeConfiguration<ReturnItem>
    {
        public ReturnItemMap()
        {
            this.ToTable("ReturnItem");
            this.Property(e => e.ReturnQuantity).HasPrecision(19, 4);
            this.Property(e => e.ReturnCost).HasPrecision(19, 4);
            this.HasOptional(e => e.Return)
                .WithMany(e => e.ReturnItems)
                .HasForeignKey(e => e.ReturnId);
            this.HasOptional(e => e.IssueItem)
                .WithMany()
                .HasForeignKey(e => e.IssueItemId);
        }
    }
}
