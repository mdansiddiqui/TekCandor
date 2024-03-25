/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    /// <summary>
    /// The argument that will be used when starting a new workflow instance.
    /// </summary>
    public class WorkflowInput
    {
        public long CreatedUserId { get; set; }
        public long EntityId { get; set; }
        public string EntityType { get; set; }
        public long WorkflowDefinitionId { get; set; }
    }
}
