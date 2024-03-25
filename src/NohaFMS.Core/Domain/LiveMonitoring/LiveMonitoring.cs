
using System.ComponentModel.DataAnnotations.Schema;


namespace NohaFMS.Core.Domain
{
    [System.ComponentModel.DataAnnotations.Schema.Table("LiveMonitoring")]
    public class LiveMonitoring : BaseEntity
    {    //NAme, BranchCode,BeanchHub,CityNAme
        [Column(TypeName ="varchar")]
        public string LiveName { get; set; }
        [Column(TypeName = "varchar")]
        public string BranchName { get; set; }
        [Column(TypeName = "varchar")]
        public string BranchCode { get; set; }
        [Column(TypeName = "varchar")]
        public string CityName { get; set; }

    }
}
