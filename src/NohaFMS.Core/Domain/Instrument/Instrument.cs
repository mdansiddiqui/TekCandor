
using System.ComponentModel.DataAnnotations.Schema;

namespace NohaFMS.Core.Domain
{
    public class Instrument : BaseEntity
    {

        [Column(TypeName = "varchar")]
        public string code { get; set; }
        [Column(TypeName = "varchar")]
        public string Name { get; set; }
         
    }
}
