using System;

namespace NohaFMS.Web.Models
{
    public class UserActivityLogsModel
    {
        public string Description { get; set; }

        public string UserId { get; set; }

        public string UrlAccess { get; set; }

        public DateTime CreatedLog { get; set; }
    }
}