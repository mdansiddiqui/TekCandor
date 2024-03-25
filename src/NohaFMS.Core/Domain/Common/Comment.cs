/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class Comment : BaseEntity
    {
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
        public string Message { get; set; }
    }
}
