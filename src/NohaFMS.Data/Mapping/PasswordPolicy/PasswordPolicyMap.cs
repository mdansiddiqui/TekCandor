using NohaFMS.Core.Domain;


namespace NohaFMS.Data.Mapping
{
    public class PasswordPolicyMapMap : NohaFMSEntityTypeConfiguration<PasswordPolicy>
    {
        public PasswordPolicyMapMap()
        {
            this.ToTable("PasswordPolicy");
            this.Property(s => s.Id);

        }
    }
}
