using System;

namespace NohaFMS.Web.Models.Config
{
    public class AppConfigModel
    {
        public long Id { get; set; }
        public long? key { get; set; }

        public string value { get; set; }
        public string CreatedUser { get; set; }
        public DateTime CreatedDateTime { get; set; }

    }
}