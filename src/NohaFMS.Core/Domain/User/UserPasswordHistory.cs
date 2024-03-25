/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    public partial class UserPasswordHistory : BaseEntity
    {
        /// <summary>
        /// The hashed Password string.
        /// </summary>
        public string LoginPassword { get; set; }

        public long? UserId { get; set; }
        public virtual User Owner { get; set; }
    }
}
