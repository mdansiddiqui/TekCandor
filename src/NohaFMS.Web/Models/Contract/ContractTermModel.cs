/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ContractTermValidator))]
    public class ContractTermModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Common.Sequence")]
        public int? Sequence { get; set; }

        [BaseEamResourceDisplayName("Common.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Common.Description")]
        public string Description { get; set; }

        public long? ContractId { get; set; }
    }
}