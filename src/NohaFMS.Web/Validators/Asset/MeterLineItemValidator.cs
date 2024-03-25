using FluentValidation;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using NohaFMS.Services;

namespace NohaFMS.Web.Validators
{
    public class MeterLineItemValidator : BaseEamValidator<MeterLineItemModel>
    {
        public MeterLineItemValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.DisplayOrder).NotEmpty().WithMessage(localizationService.GetResource("MeterLineItem.DisplayOrder.Required"));
        }
    }
}