using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{

    public class ShiftValidator : BaseEamValidator<ShiftModel>
    {
        private readonly IRepository<Shift> _shiftRepository;
        public ShiftValidator(ILocalizationService localizationService, IRepository<Shift> shiftRepository)
        {
            this._shiftRepository = shiftRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Shift.Name.Required"));
            RuleFor(x => x.CalendarId).NotEmpty().WithMessage(localizationService.GetResource("Shift.Calendar.Required"));
            RuleFor(x => x.DaysInPattern).NotEmpty().WithMessage(localizationService.GetResource("Shift.DaysInPattern.Required"));
            RuleFor(x => x.StartDay.ToString()).NotEmpty().WithMessage(localizationService.GetResource("Shift.StartDay.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Shift.Name.Unique"));
        }

        private bool NoDuplication(ShiftModel model)
        {
            var shift = _shiftRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return shift == null;
        }
    }
}