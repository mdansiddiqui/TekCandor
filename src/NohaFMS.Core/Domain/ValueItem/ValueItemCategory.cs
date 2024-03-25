/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    [Table("ValueItemCategory")]
    public partial class ValueItemCategory : BaseEntity
    {
        private ICollection<ValueItem> _valueItems;

        [Dapper.Contrib.Extensions.Write(false)]
        public virtual ICollection<ValueItem> ValueItems
        {
            get { return _valueItems ?? (_valueItems = new List<ValueItem>()); }
            protected set { _valueItems = value; }
        }
    }
}
