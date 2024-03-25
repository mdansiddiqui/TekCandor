/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ContractTermMap : NohaFMSEntityTypeConfiguration<ContractTerm>
    {
        public ContractTermMap()
            : base()
        {
            this.ToTable("ContractTerm");
            this.Property(e => e.Description).HasMaxLength(512);
            this.HasOptional(e => e.Contract)
                .WithMany(e => e.ContractTerms)
                .HasForeignKey(e => e.ContractId);
        }
    }
}
