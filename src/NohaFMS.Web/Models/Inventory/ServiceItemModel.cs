﻿using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ServiceItemValidator))]
    public class ServiceItemModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("ServiceItem.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("ServiceItem.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("ServiceItem.UnitPrice")]
        [UIHint("DecimalNullable")]
        public decimal? UnitPrice { get; set; }

        [BaseEamResourceDisplayName("ServiceItem.ItemGroup")]
        public long? ItemGroupId { get; set; }
        public ItemGroupModel ItemGroup { get; set; }

        [BaseEamResourceDisplayName("ServiceItem.IsActive")]
        public bool IsActive { get; set; }

    }
}