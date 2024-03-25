/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System.Linq;

namespace NohaFMS.Web.Validators
{
    public class LocationValidator : BaseEamValidator<LocationModel>
    {
        private readonly IRepository<Location> _locationRepository;
        public LocationValidator(ILocalizationService localizationService, IRepository<Location> locationRepository)
        {
            this._locationRepository = locationRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Location.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Location.Name.Unique"));
            RuleFor(x => x.SiteId).NotEmpty().WithMessage(localizationService.GetResource("Site.Required"));
            RuleFor(x => x.LocationTypeId).NotEmpty().WithMessage(localizationService.GetResource("Location.LocationType.Required"));
            RuleFor(x => x.LocationStatusId).NotEmpty().WithMessage(localizationService.GetResource("Location.LocationStatus.Required"));
        }

        private bool NoDuplication(LocationModel model)
        {
            var location = _locationRepository.GetAll().Where(c => c.Name == model.Name && c.SiteId == model.SiteId && c.Id != model.Id).FirstOrDefault();
            return location == null;
        }
    }
}