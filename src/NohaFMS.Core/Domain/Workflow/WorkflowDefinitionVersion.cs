/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class WorkflowDefinitionVersion : BaseEntity
    {
        public long? WorkflowDefinitionId { get; set; }
        public virtual WorkflowDefinition WorkflowDefinition { get; set; }

        public int? WorkflowVersion { get; set; }

        public string WorkflowXamlFileName { get; set; }
        public string WorkflowXamlFileContent { get; set; }
        public string WorkflowPictureFileName { get; set; }
        public byte[] WorkflowPictureFileContent { get; set; }
    }
}
