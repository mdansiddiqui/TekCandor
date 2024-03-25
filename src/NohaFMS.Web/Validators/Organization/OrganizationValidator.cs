/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using Autofac;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System.Linq;

namespace NohaFMS.Web.Validators
{
    public class OrganizationValidator : BaseEamValidator<OrganizationModel>
    {
        private readonly IRepository<Organization> _organizationRepository;
        public OrganizationValidator(ILocalizationService localizationService, IRepository<Organization> organizationRepository)
        {
            this._organizationRepository = organizationRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Organization.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Organization.Name.Unique"));
        }

        private bool NoDuplication(OrganizationModel model)
        {
            var organization = _organizationRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return organization == null;
        }
    }
}