using NohaFMS.Core.Domain;


namespace NohaFMS.Data.Mapping
{
    public class CityMapMap : NohaFMSEntityTypeConfiguration<City>
    {
        public CityMapMap()
        {
            this.ToTable("City");
            this.Property(s => s.Code).HasMaxLength(128);

        }
    }
}
