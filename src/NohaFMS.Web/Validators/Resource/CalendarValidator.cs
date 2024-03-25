using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class CalendarValidator : BaseEamValidator<CalendarModel>
    {
        private readonly IRepository<Calendar> _calendarRepository;
        public CalendarValidator(ILocalizationService localizationService, IRepository<Calendar> calendarRepository)
        {
            this._calendarRepository = calendarRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Calendar.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Calendar.Name.Unique"));
        }

        private bool NoDuplication(CalendarModel model)
        {
            var calendar = _calendarRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return calendar == null;
        }
    }
}