using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    class HubMapMap : NohaFMSEntityTypeConfiguration<Hub>
    {
        public HubMapMap()
        {
            this.ToTable("Hub");
            this.Property(s => s.Code).HasMaxLength(128);
            this.HasOptional(e => e.City)
               .WithMany(e => e.Hubs)
               .HasForeignKey(e => e.CityId);
        }
    }
}
