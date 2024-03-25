using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class ItemValidator : BaseEamValidator<ItemModel>
    {
        private readonly IRepository<Item> _itemRepository;
        public ItemValidator(ILocalizationService localizationService, IRepository<Item> itemRepository)
        {
            this._itemRepository = itemRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Item.Name.Required"));
            RuleFor(x => x.ItemGroupId).NotEmpty().WithMessage(localizationService.GetResource("Item.ItemGroup.Required"));
            RuleFor(x => x.UnitOfMeasureId).NotEmpty().WithMessage(localizationService.GetResource("Item.UnitOfMeasure.Required"));
            RuleFor(x => x.ItemStatusId).NotEmpty().WithMessage(localizationService.GetResource("Item.ItemStatusId.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Item.Name.Unique"));
        }

        private bool NoDuplication(ItemModel model)
        {
            var item = _itemRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return item == null;
        }
    }
}