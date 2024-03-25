using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;

namespace NohaFMS.Web.Models
{
    [FluentValidation.Attributes.Validator(typeof(ReportValidator))]
    public class MyReportModel:BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("MyReport.Id")]
        public int id { get; set; }

        [BaseEamResourceDisplayName("MyReport.name")]
        public string name { get; set; }

        [BaseEamResourceDisplayName("MyReport.url")]
        public string url { get; set; }
    }
}