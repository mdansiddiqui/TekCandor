using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NohaFMS.Core.Domain
{
    [Table("WorkflowInstance")]
    public class WorkflowInstance : BaseEntity
    {
        public string InstanceId { get; set; }
        public string InstanceData { get; set; }
    }
}
