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
    public class WorkOrderServiceItemValidator : BaseEamValidator<WorkOrderServiceItemModel>
    {
        private readonly IRepository<WorkOrderServiceItem> _workOrderServiceItemRepository;
        public WorkOrderServiceItemValidator(ILocalizationService localizationService, IRepository<WorkOrderServiceItem> workOrderServiceItemRepository)
        {
            this._workOrderServiceItemRepository = workOrderServiceItemRepository;
            RuleFor(x => x.ServiceItemId).NotEmpty().WithMessage(localizationService.GetResource("ServiceItem.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("ServiceItem.Unique"));
        }

        private bool NoDuplication(WorkOrderServiceItemModel model)
        {
            var workOrderServiceItem = _workOrderServiceItemRepository.GetAll().Where(c => c.ServiceItemId == model.ServiceItemId && c.Id != model.Id).FirstOrDefault();
            return workOrderServiceItem == null;
        }
    }
}