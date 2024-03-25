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
    public class CodeValidator : BaseEamValidator<CodeModel>
    {
        private readonly IRepository<Code> _codeRepository;
        public CodeValidator(ILocalizationService localizationService, IRepository<Code> codeRepository)
        {
            this._codeRepository = codeRepository;

            RuleFor(x => x.Name).NotEmpty().WithMessage(localizationService.GetResource("Code.Name.Required"));
            RuleFor(x => x).Must(NoDuplication).WithMessage(localizationService.GetResource("Code.Name.Unique"));
        }

        private bool NoDuplication(CodeModel model)
        {
            var code = _codeRepository.GetAll().Where(c => c.Name == model.Name && c.Id != model.Id).FirstOrDefault();
            return code == null;
        }
    }
}