/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class ReturnReasonMap : NohaFMSEntityTypeConfiguration<ReturnReason>
    {
        public ReturnReasonMap()
        {
            this.ToTable("ReturnReason");
            this.Property(s => s.code).HasMaxLength(50);
            this.Property(s => s.AlphaReturnCodes);
            this.Property(s => s.NumericReturnCodes);
            this.Property(s => s.DescriptionWithReturnCodes).HasMaxLength(500);
            this.Property(s => s.Status);








        }

    }
}
