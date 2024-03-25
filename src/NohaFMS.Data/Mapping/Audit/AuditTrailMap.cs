/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class AuditTrailMap : NohaFMSEntityTypeConfiguration<AuditTrail>
    {
        public AuditTrailMap()
            : base()
        {
            this.ToTable("AuditTrail");
        }
    }
}
