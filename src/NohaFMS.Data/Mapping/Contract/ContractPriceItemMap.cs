/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ContractPriceItemMap : NohaFMSEntityTypeConfiguration<ContractPriceItem>
    {
        public ContractPriceItemMap()
            : base()
        {
            this.ToTable("ContractPriceItem");
            this.Property(e => e.ContractedPrice).HasPrecision(19, 4);
            this.HasOptional(e => e.Contract)
                .WithMany(e => e.ContractPriceItems)
                .HasForeignKey(e => e.ContractId);
            this.HasOptional(e => e.Item)
                .WithMany()
                .HasForeignKey(e => e.ItemId);
        }
    }
}
