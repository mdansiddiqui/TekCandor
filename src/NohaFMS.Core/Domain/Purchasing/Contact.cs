/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using Dapper.Contrib.Extensions;

namespace NohaFMS.Core.Domain
{
    [Table("Contact")]
    public class Contact : BaseEntity
    {
        public string Position { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }

        public long? CompanyId { get; set; }
        [Write(false)]
        public virtual Company Company { get; set; }

        public long? ContractId { get; set; }
        [Write(false)]
        public virtual Contract Contract { get; set; }
    }
}
