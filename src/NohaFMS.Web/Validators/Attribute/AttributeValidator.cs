﻿using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using FluentValidation;
using System.Linq;

namespace NohaFMS.Web.Validators
{
    public class AttributeValidator : BaseEamValidator<AttributeModel>
    {
        private readonly IRepository<Attribute> _attributeRepository;
        public AttributeValidator(ILocalizationService localizationService,
            IRepository<Attribute> attributeRepository)
        {
            this._attributeRepository = attributeRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Attribute.Name.Required"));
            RuleFor(x => x.CsvTextList).NotEmpty()
                .When(x => x.DataSource == AttributeDataSource.CSV &&
                    (x.ControlType == AttributeControlType.DropDownList
                        || x.ControlType == AttributeControlType.MultiSelectList))
                .WithMessage(localizationService.GetResource("Attribute.CsvTextList.Required"));
            RuleFor(x => x.CsvValueList).NotEmpty()
                .When(x => x.DataSource == AttributeDataSource.CSV &&
                    (x.ControlType == AttributeControlType.DropDownList
                        || x.ControlType == AttributeControlType.MultiSelectList))
                .WithMessage(localizationService.GetResource("Attribute.CsvValueList.Required"));
        }

        private bool NoDuplication(AttributeModel model)
        {
            var attribute = _attributeRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return attribute == null;
        }
    }
}