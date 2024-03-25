/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;

namespace NohaFMS.Core.Domain
{
    public class WorkflowDefinition : BaseEntity
    {
        public string Description { get; set; }

        /// <summary>
        /// The workflow entity this workflow definition attached to
        /// </summary>
        public string EntityType { get; set; }

        public bool IsDefault { get; set; }

        private ICollection<WorkflowDefinitionVersion> _workflowDefinitionVersions;
        public virtual ICollection<WorkflowDefinitionVersion> WorkflowDefinitionVersions
        {
            get { return _workflowDefinitionVersions ?? (_workflowDefinitionVersions = new List<WorkflowDefinitionVersion>()); }
            protected set { _workflowDefinitionVersions = value; }
        }
    }
}
