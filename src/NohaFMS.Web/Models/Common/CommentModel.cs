using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(CommentValidator))]
    public class CommentModel : BaseEamEntityModel
    {
        public long? EntityId { get; set; }

        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("Comment.Message")]
        public string Message { get; set; }
    }
}