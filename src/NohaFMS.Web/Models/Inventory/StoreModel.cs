using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(StoreValidator))]
    public class StoreModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Store.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Store.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Store.Site")]
        public long? SiteId { get; set; }
        public SiteModel Site { get; set; }

        [BaseEamResourceDisplayName("Store.Location")]
        public long? LocationId { get; set; }
        public LocationModel Location { get; set; }

        [BaseEamResourceDisplayName("Store.StoreType")]
        public long? StoreTypeId { get; set; }
        public ValueItemModel StoreType { get; set; }

        [BaseEamResourceDisplayName("Store.IsActive")]
        public bool IsActive { get; set; }
    }
}