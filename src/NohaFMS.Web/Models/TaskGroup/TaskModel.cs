/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(TaskValidator))]
    public class TaskModel : BaseEamEntityModel
    {
        public long? TaskGroupId { get; set; }

        [BaseEamResourceDisplayName("Task.Sequence")]
        public int Sequence { get; set; }

        [BaseEamResourceDisplayName("Task.Description")]
        public string Description { get; set; }

    }
}