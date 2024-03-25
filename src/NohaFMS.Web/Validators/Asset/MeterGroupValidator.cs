﻿using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Validators;
using NohaFMS.Web.Models;
using System.Linq;
using FluentValidation;

namespace NohaFMS.Web.Validators
{
    public class MeterGroupValidator : BaseEamValidator<MeterGroupModel>
    {
        private readonly IRepository<MeterGroup> _meterGroupRepository;
        public MeterGroupValidator(ILocalizationService localizationService, IRepository<MeterGroup> meterGroupRepository)
        {
            this._meterGroupRepository = meterGroupRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("MeterGroup.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("MeterGroup.Name.Unique"));
        }

        private bool NoDuplication(MeterGroupModel model)
        {
            var meterGroup = _meterGroupRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return meterGroup == null;
        }
    }
}