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
    public class ValueItemCategoryValidator : BaseEamValidator<ValueItemCategoryModel>
    {
        private readonly IRepository<ValueItemCategory> _valueItemCategoryRepository;
        public ValueItemCategoryValidator(ILocalizationService localizationService, IRepository<ValueItemCategory> valueItemCategoryRepository)
        {
            this._valueItemCategoryRepository = valueItemCategoryRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("ValueItemCategory.Name.Required"));
            //RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("ValueItemCategory.Name.Unique"));
        }

        private bool NoDuplication(ValueItemCategoryModel model)
        {
            var valueItemCategory = _valueItemCategoryRepository.GetAll().Where(c => c.Name == model.Name && (c.Id != model.Id)).FirstOrDefault();
            return valueItemCategory == null;
        }
    }
}