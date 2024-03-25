using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
        public class BranchMapMap : NohaFMSEntityTypeConfiguration<Branch>
    {
        public BranchMapMap()
        {
            this.ToTable("Branch");
            this.Property(s => s.Code).HasMaxLength(128);
            this.HasOptional(e => e.Hub)
                .WithMany(e => e.Branchs)
                .HasForeignKey(e => e.HubId);
        }
    }
}

