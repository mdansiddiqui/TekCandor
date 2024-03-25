/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
namespace NohaFMS.Core.Domain
{
    public class Task : BaseEntity
    {
        public int Sequence { get; set; }
        public string Description { get; set; }

        public long? TaskGroupId { get; set; }
        public virtual TaskGroup TaskGroup { get; set; }
    }
}
