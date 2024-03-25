using NohaFMS.Core.Domain;

namespace NohaFMS.Data.Mapping
{
    class LiveMonitoringMap:NohaFMSEntityTypeConfiguration<LiveMonitoring>
    {
        public LiveMonitoringMap()
        {
            this.ToTable("LiveMonitoring");
            this.Property(s => s.LiveName).HasMaxLength(10);
            this.Property(s=>s.BranchName).HasMaxLength(10);
            this.Property(s => s.BranchCode).HasMaxLength(10);
            this.Property(s => s.CityName).HasMaxLength(10);
        }

    }
}
