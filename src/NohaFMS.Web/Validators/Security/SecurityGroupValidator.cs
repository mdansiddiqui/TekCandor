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
    public class SecurityGroupValidator : BaseEamValidator<SecurityGroupModel>
    {
        private readonly IRepository<SecurityGroup> _securityGroupRepository;
        public SecurityGroupValidator(ILocalizationService localizationService, IRepository<SecurityGroup> securityGroupRepository)
        {
            this._securityGroupRepository = securityGroupRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("SecurityGroup.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("SecurityGroup.Name.Unique"));
        }

        private bool NoDuplication(SecurityGroupModel model)
        {
            var securityGroup = _securityGroupRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return securityGroup == null;
        }
    }
}