/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using System.Linq;
using FluentValidation;
using NohaFMS.Web.Models;
using NohaFMS.Web.Framework.Validators;

namespace NohaFMS.Web.Validators
{
    public class AuditEntityConfigurationValidator : BaseEamValidator<AuditEntityConfigurationModel>
    {
        private readonly IRepository<AuditEntityConfiguration> _auditEntityConfigurationRepository;
        public AuditEntityConfigurationValidator(ILocalizationService localizationService,
            IRepository<AuditEntityConfiguration> auditEntityConfigurationRepository)
        {
            this._auditEntityConfigurationRepository = auditEntityConfigurationRepository;

            RuleFor(x => x.EntityType).NotEmpty().WithMessage(localizationService.GetResource("EntityType.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("EntityType.Unique"));
        }

        private bool NoDuplication(AuditEntityConfigurationModel model)
        {
            var auditEntityConfiguration = _auditEntityConfigurationRepository.GetAll().Where(c => c.EntityType == model.EntityType && c.Id != model.Id).FirstOrDefault();
            return auditEntityConfiguration == null;
        }
    }
}