/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class MeterLineItemMap : NohaFMSEntityTypeConfiguration<MeterLineItem>
    {
        public MeterLineItemMap()
        {
            this.ToTable("MeterLineItem");
            this.HasOptional(e => e.Meter)
                .WithMany()
                .HasForeignKey(e => e.MeterId);
            this.HasOptional(e => e.MeterGroup)
                .WithMany(e => e.MeterLineItems)
                .HasForeignKey(e => e.MeterGroupId)
                .WillCascadeOnDelete(true);
        }
    }
}
