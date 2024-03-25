/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using System.Linq;
using FluentValidation;
using NohaFMS.Web.Models;
using NohaFMS.Web.Framework.Validators;

namespace NohaFMS.Web.Validators
{
    public class ImportProfileValidator : BaseEamValidator<ImportProfileModel>
    {
        private readonly IRepository<ImportProfile> _importProfileRepository;
        public ImportProfileValidator(ILocalizationService localizationService,
            IRepository<ImportProfile> importProfileRepository)
        {
            this._importProfileRepository = importProfileRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("ImportProfile.Name.Required"));
            RuleFor(x => x.EntityType).NotEmpty().WithMessage(localizationService.GetResource("EntityType.Required"));
        }

        private bool NoDuplication(ImportProfileModel model)
        {
            var module = _importProfileRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return module == null;
        }
    }
}