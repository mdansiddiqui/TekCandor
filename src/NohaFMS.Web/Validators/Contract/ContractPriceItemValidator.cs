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
    public class ContractPriceItemValidator : BaseEamValidator<ContractPriceItemModel>
    {
        private readonly IRepository<ContractPriceItem> _contractPriceItemRepository;
        public ContractPriceItemValidator(ILocalizationService localizationService, IRepository<ContractPriceItem> contractPriceItemRepository)
        {
            this._contractPriceItemRepository = contractPriceItemRepository;

            RuleFor(x => x.ItemId).NotEmpty().WithMessage(localizationService.GetResource("Item.Required"));
            RuleFor(x => x.ContractedPrice).NotEmpty().WithMessage(localizationService.GetResource("ContractPriceItem.ContractedPrice.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Item.Unique"));
        }

        private bool NoDuplication(ContractPriceItemModel model)
        {
            var contractPriceItem = _contractPriceItemRepository.GetAll()
                .Where(c => c.ItemId == model.ItemId && c.Id != model.Id && c.ContractId == model.ContractId).FirstOrDefault();
            return contractPriceItem == null;
        }
    }
}