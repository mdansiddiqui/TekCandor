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
    [Validator(typeof(PMTaskValidator))]
    public class PMTaskModel : BaseEamEntityModel
    {
        public long? PreventiveMaintenanceId { get; set; }

        [BaseEamResourceDisplayName("PreventiveMaintenance.Number")]
        public string PreventiveMaintenanceNumber { get; set; }

        [BaseEamResourceDisplayName("TaskGroup")]
        public long? TaskGroupId { get; set; }

        [BaseEamResourceDisplayName("PMTask.Sequence")]
        [UIHint("Int32Nullable")]
        public int? Sequence { get; set; }

        [BaseEamResourceDisplayName("PMTask.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("AssignedUser")]
        public long? AssignedUserId { get; set; }
        public string AssignedUserUserName { get; set; }
    }
}