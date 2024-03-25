using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;

namespace NohaFMS.Web.Validators
{

    public class ShiftPatternValidator : BaseEamValidator<ShiftPatternModel>
    {
        public ShiftPatternValidator(ILocalizationService localizationService)
        {
            RuleFor(x => x.StartTime).NotEmpty().WithMessage(localizationService.GetResource("ShiftPattern.StartTime.Required"));
            RuleFor(x => x.EndTime).NotEmpty().WithMessage(localizationService.GetResource("ShiftPattern.EndTime.Required"));
        }
    }
}