/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class WorkflowVariable
    {
        public long CurrentUserId { get; set; }
        public string CurrentAction { get; set; }
        public string CurrentComment { get; set; }
        public long EntityId { get; set; }
        public string EntityType { get; set; }
        public long WorkflowDefinitionId { get; set; }
    }
}
