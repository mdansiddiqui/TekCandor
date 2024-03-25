using System;
using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain
{
    [Table("ApplicationConfig")]
    public class Config : BaseEntity
    {
        public long Id { get; set; }
        public string key { get; set; }

        public string value { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}
