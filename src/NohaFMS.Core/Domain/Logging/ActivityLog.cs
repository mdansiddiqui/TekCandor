﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/

namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// Represents an activity log record
    /// </summary>
    public partial class ActivityLog : BaseEntity
    {
        /// <summary>
        /// Ctor
        /// </summary>
        public ActivityLog()
        {
        }

        /// <summary>
        /// Gets or sets the activity log type identifier
        /// </summary>
        public long ActivityLogTypeId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the activity comment
        /// </summary>
        public string Comment { get; set; }

        /// <summary>
        /// Gets the activity log type
        /// </summary>
        public virtual ActivityLogType ActivityLogType { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }
        
        /// <summary>
        /// Gets the user
        /// </summary>
        public virtual User User { get; set; }
    }
}
