
using System.Collections.Generic;


namespace NohaFMS.Core.Domain
{
    public class MyReport :BaseEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        private ICollection<ReportFilter> _reportFilters;
        public virtual ICollection<ReportFilter> ReportFilters
        {
            get { return _reportFilters ?? (_reportFilters = new List<ReportFilter>()); }
            protected set { _reportFilters = value; }
        }

        private ICollection<ReportColumn> _reportColumns;
        public virtual ICollection<ReportColumn> ReportColumns
        {
            get { return _reportColumns ?? (_reportColumns = new List<ReportColumn>()); }
            protected set { _reportColumns = value; }
        }
    }
}
