//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace NohaFMS.Web.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class ActivityLog
    {
        public long Id { get; set; }
        public long ActivityLogTypeId { get; set; }
        public long UserId { get; set; }
        public string Comment { get; set; }
        public string Name { get; set; }
        public bool IsNew { get; set; }
        public bool IsDeleted { get; set; }
        public string CreatedUser { get; set; }
        public Nullable<System.DateTime> CreatedDateTime { get; set; }
        public string ModifiedUser { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public int Version { get; set; }
        public string Description { get; set; }
    }
}
