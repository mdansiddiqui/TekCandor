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

namespace NohaFMS.Web.Validators
{
    public class ReturnItemValidator : BaseEamValidator<ReturnItemModel>
    {
        private readonly IRepository<IssueItem> _issueItemRepository;
        public ReturnItemValidator(ILocalizationService localizationService,
            IRepository<ReturnItem> returnItemRepository,
            IRepository<IssueItem> issueItemRepository)
        {
            this._issueItemRepository = issueItemRepository;

            RuleFor(x => x.ReturnQuantity).NotEmpty().WithMessage(localizationService.GetResource("ReturnItem.Quantity.Required"));
        }
    }
}