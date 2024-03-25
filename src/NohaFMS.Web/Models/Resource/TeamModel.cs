using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(TeamValidator))]
    public class TeamModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Team.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Team.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Team.Site")]
        public long? SiteId { get; set; }
        public SiteModel Site { get; set; }

    }
}