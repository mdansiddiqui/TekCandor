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
    public class CompanyValidator : BaseEamValidator<CompanyModel>
    {
        private readonly IRepository<Company> _companyRepository;
        public CompanyValidator(ILocalizationService localizationService, IRepository<Company> companyRepository)
        {
            this._companyRepository = companyRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Company.Name.Required"));
            RuleFor(x => x.CompanyTypeId).NotEmpty().WithMessage(localizationService.GetResource("Company.CompanyType.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Company.Name.Unique"));
        }

        private bool NoDuplication(CompanyModel model)
        {
            var company = _companyRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return company == null;
        }
    }
}