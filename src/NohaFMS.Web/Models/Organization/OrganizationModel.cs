/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(OrganizationValidator))]
    public class OrganizationModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Organization.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("Organization.Description")]
        public string Description { get; set; }

        public InventorySettingsModel InventorySettings { get; set; }

        public ItemCostingType CostingType { get; set; }
    }
}