using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class UnitConversionValidator : BaseEamValidator<UnitConversionModel>
    {
        private readonly IRepository<UnitConversion> _unitConversionRepository;
        public UnitConversionValidator(ILocalizationService localizationService, IRepository<UnitConversion> unitConversionRepository)
        {
            this._unitConversionRepository = unitConversionRepository;
            RuleFor(x => x.FromUnitOfMeasure).NotNull().WithMessage(localizationService.GetResource("UnitConversion.FromUnitOfMeasure.Required"));
            RuleFor(x => x.ToUnitOfMeasure).NotNull().WithMessage(localizationService.GetResource("UnitConversion.ToUnitOfMeasure.Required"));
            RuleFor(x => x.ConversionFactor).NotEmpty().WithMessage(localizationService.GetResource("UnitConversion.ConversionFactor.Required"));
        }
    }
}