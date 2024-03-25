using NohaFMS.Core.Domain;


namespace NohaFMS.Data.Mapping
{
    public class BankMapMap : NohaFMSEntityTypeConfiguration<Bank>
    {
        public BankMapMap()
        {
            this.ToTable("Bank");
            this.Property(s => s.Code).HasMaxLength(256);

        }
    }
}
