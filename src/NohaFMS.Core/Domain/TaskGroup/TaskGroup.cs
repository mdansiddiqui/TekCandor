/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class TaskGroup : BaseEntity
    {
        public string Description { get; set; }

        private ICollection<Task> _tasks;
        public virtual ICollection<Task> Tasks
        {
            get { return _tasks ?? (_tasks = new List<Task>()); }
            protected set { _tasks = value; }
        }

        /// <summary>
        /// Concatenation of Asset Type
        /// </summary>
        public string AssetTypes { get; set; }
    }
}
