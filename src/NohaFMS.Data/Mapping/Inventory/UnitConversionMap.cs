/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class UnitConversionMap : NohaFMSEntityTypeConfiguration<UnitConversion>
    {
        public UnitConversionMap()
        {
            this.ToTable("UnitConversion");
            this.HasOptional(e => e.FromUnitOfMeasure)
                .WithMany()
                .HasForeignKey(e => e.FromUnitOfMeasureId);
            this.HasOptional(e => e.ToUnitOfMeasure)
                .WithMany()
                .HasForeignKey(e => e.ToUnitOfMeasureId);
            this.Property(e => e.ConversionFactor).HasPrecision(19, 4);
        }
    }
}
