using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class CommentValidator : BaseEamValidator<CommentModel>
    {
        public CommentValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.Message).NotEmpty().WithMessage(localizationService.GetResource("Comment.Message.Required"));
        }
    }
}