using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{

    public class TechnicianValidator : BaseEamValidator<TechnicianModel>
    {
        private readonly IRepository<Technician> _technicianRepository;
        public TechnicianValidator(ILocalizationService localizationService, IRepository<Technician> technicianRepository)
        {
            this._technicianRepository = technicianRepository;

            RuleFor(x => x.UserId).NotEmpty().WithMessage(localizationService.GetResource("Technician.User.Required"));
            RuleFor(x => x.CalendarId).NotEmpty().WithMessage(localizationService.GetResource("Technician.Calendar.Required"));
            RuleFor(x => x.ShiftId).NotEmpty().WithMessage(localizationService.GetResource("Technician.Shift.Required"));
            RuleFor(x => x.CraftId).NotEmpty().WithMessage(localizationService.GetResource("Technician.Craft.Required"));
            RuleFor(x => x).Must(HaveAssignedToOneUser).WithMessage(localizationService.GetResource("Technician.User.HaveAssignedToOneUser"));
        }

        public bool HaveAssignedToOneUser(TechnicianModel model)
        {
            var technician = _technicianRepository.GetAll().Where(t => t.UserId == model.UserId && t.Id != model.Id).FirstOrDefault();
            return technician == null;
        }
    }
}