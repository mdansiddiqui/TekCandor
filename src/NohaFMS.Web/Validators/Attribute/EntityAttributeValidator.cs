using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class EntityAttributeValidator : BaseEamValidator<EntityAttributeModel>
    {
        public EntityAttributeValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage(localizationService.GetResource("Attribute.DisplayOrder.Required"));
        }
    }
}