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
    public class FeatureValidator : BaseEamValidator<FeatureModel>
    {
        private readonly IRepository<Feature> _featureRepository;
        public FeatureValidator(ILocalizationService localizationService, IRepository<Feature> featureRepository)
        {
            this._featureRepository = featureRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Feature.Name.Required"));
            RuleFor(x => x.ModuleId).NotEmpty().WithMessage(localizationService.GetResource("Feature.Module.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Feature.Name.Unique"));
            RuleFor(x => x.DisplayOrder).GreaterThan(0).WithMessage(localizationService.GetResource("Common.DisplayOrder.GreaterThanZero"));
        }

        private bool NoDuplication(FeatureModel model)
        {
            var feature = _featureRepository.GetAll().Where(c => c.Name == model.Name && c.ModuleId == model.ModuleId && c.Id != model.Id).FirstOrDefault();
            return feature == null;
        }
    }
}