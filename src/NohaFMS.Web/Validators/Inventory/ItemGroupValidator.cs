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
    public class ItemGroupValidator : BaseEamValidator<ItemGroupModel>
    {
        private readonly IRepository<ItemGroup> _itemGroupRepository;
        public ItemGroupValidator(ILocalizationService localizationService, IRepository<ItemGroup> itemGroupRepository)
        {
            this._itemGroupRepository = itemGroupRepository;
            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("ItemGroup.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("ItemGroup.Name.Unique"));
        }

        private bool NoDuplication(ItemGroupModel model)
        {
            var itemGroup = _itemGroupRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return itemGroup == null;
        }
    }
}