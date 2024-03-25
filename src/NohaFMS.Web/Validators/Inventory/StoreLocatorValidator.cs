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
    public class StoreLocatorValidator : BaseEamValidator<StoreLocatorModel>
    {
        private readonly IRepository<StoreLocator> _storeLocatorRepository;
        public StoreLocatorValidator(ILocalizationService localizationService, IRepository<StoreLocator> storeRepository)
        {
            this._storeLocatorRepository = storeRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("StoreLocator.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("StoreLocator.Name.Unique"));
        }

        private bool NoDuplication(StoreLocatorModel model)
        {
            var storeLocator = _storeLocatorRepository.GetAll().Where(c => c.Name == model.Name && c.StoreId == model.StoreId && c.Id != model.Id).FirstOrDefault();
            return storeLocator == null;
        }
    }
}