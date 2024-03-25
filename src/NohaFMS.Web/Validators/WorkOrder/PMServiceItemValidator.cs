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
    public class PMServiceItemValidator : BaseEamValidator<PMServiceItemModel>
    {
        private readonly IRepository<PMServiceItem> _pMServiceItemRepository;
        public PMServiceItemValidator(ILocalizationService localizationService, IRepository<PMServiceItem> pMServiceItemRepository)
        {
            this._pMServiceItemRepository = pMServiceItemRepository;
            RuleFor(x => x.ServiceItemId).NotEmpty().WithMessage(localizationService.GetResource("ServiceItem.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("ServiceItem.Unique"));
        }

        private bool NoDuplication(PMServiceItemModel model)
        {
            var pMServiceItem = _pMServiceItemRepository.GetAll().Where(c => c.ServiceItemId == model.ServiceItemId && c.Id != model.Id).FirstOrDefault();
            return pMServiceItem == null;
        }
    }
}