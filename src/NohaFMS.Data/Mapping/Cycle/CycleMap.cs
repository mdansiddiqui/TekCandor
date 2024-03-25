using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    public class CycleMapMap : NohaFMSEntityTypeConfiguration<Cycle>
    {
        public CycleMapMap()
        {
            this.ToTable("Cycle");
            this.Property(s => s.Description);
            this.Property(s => s.Code).HasMaxLength(128);

        }
    }
}

