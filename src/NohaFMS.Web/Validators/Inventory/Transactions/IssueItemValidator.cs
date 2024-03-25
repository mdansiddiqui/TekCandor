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
    public class IssueItemValidator : BaseEamValidator<IssueItemModel>
    {
        private readonly IRepository<IssueItem> _issueItemRepository;
        public IssueItemValidator(ILocalizationService localizationService, IRepository<IssueItem> issueItemRepository)
        {
            this._issueItemRepository = issueItemRepository;

            RuleFor(x => x).Must(StoreLocatorRequired).WithMessage(localizationService.GetResource("IssueItem.StoreLocator.Required"));
            RuleFor(x => x.ItemId).NotEmpty().WithMessage(localizationService.GetResource("IssueItem.Item.Required"));
            RuleFor(x => x.IssueUnitOfMeasureId).NotEmpty().WithMessage(localizationService.GetResource("UnitOfMeasure.Required"));
            RuleFor(x => x.IssueQuantity).NotEmpty().WithMessage(localizationService.GetResource("IssueItem.Quantity.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("IssueItem.Unique"));
        }

        private bool StoreLocatorRequired(IssueItemModel model)
        {
            return (model.StoreLocatorId != null && model.StoreLocatorId != 0) ||
                        (model.StoreLocator != null && model.StoreLocator.Id != 0);
        }

        private bool NoDuplication(IssueItemModel model)
        {
            var issueItem = _issueItemRepository.GetAll()
                .Where(c => c.StoreLocatorId == model.StoreLocatorId && c.ItemId == model.ItemId && c.Id != model.Id && c.IssueId == model.IssueId).FirstOrDefault();
            return issueItem == null;
        }
    }
}