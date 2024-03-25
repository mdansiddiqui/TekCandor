using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{

    public class CalendarNonWorkingValidator : BaseEamValidator<CalendarNonWorkingModel>
    {
        private readonly IRepository<CalendarNonWorking> _calendarNonWorkingRepository;
        public CalendarNonWorkingValidator(ILocalizationService localizationService, IRepository<CalendarNonWorking> calendarNonWorkingRepository)
        {
            this._calendarNonWorkingRepository = calendarNonWorkingRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("CalendarNonWorking.Name.Required"));
            RuleFor(x => x.NonWorkingDate).NotEmpty().WithMessage(localizationService.GetResource("CalendarNonWorking.NonWorkingDate.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("CalendarNonWorking.Name.Unique"));
        }

        private bool NoDuplication(CalendarNonWorkingModel model)
        {
            var calendarNonWorking = _calendarNonWorkingRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return calendarNonWorking == null;
        }
    }
}