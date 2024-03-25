/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(TaskGroupValidator))]
    public class TaskGroupModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("TaskGroup.Name")]
        public string Name { get; set; }

        [MaxLength(512)]
        [BaseEamResourceDisplayName("TaskGroup.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("TaskGroup.AssetType")]
        public long? AssetTypeId { get; set; }
        public string AssetTypeName { get; set; }
    }
}