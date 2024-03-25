﻿/*******************************************************
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
    public class SiteValidator : BaseEamValidator<SiteModel>
    {
        private readonly IRepository<Site> _siteRepository;
        public SiteValidator(ILocalizationService localizationService, IRepository<Site> siteRepository)
        {
            this._siteRepository = siteRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Site.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Site.Name.Unique"));
        }

        private bool NoDuplication(SiteModel model)
        {
            var site = _siteRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return site == null;
        }
    }
}