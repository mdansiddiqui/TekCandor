using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System.Linq;

namespace NohaFMS.Web.Validators
{
    public class UnitOfMeasureValidator : BaseEamValidator<UnitOfMeasureModel>
    {
        private readonly IRepository<UnitOfMeasure> _unitOfMeasureRepository;

        public UnitOfMeasureValidator(ILocalizationService localizationService, IRepository<UnitOfMeasure> unitOfMeasureRepository)
        {
            this._unitOfMeasureRepository = unitOfMeasureRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("UnitOfMeasure.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("UnitOfMeasure.Name.Unique"));
        }

        private bool NoDuplication(UnitOfMeasureModel model)
        {
            var unitOfMeasure = _unitOfMeasureRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return unitOfMeasure == null;
        }
    }
}