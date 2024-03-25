/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class Picture : BaseEntity
    {
        public byte[] ImageBytes { get; set; }
        public string Extension { get; set; }        
        public string ContentType { get; set; }
        public long? EntityId { get; set; }
        public string EntityType { get; set; }
    }
}
