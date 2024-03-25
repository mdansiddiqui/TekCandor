﻿/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(IssueValidator))]
    public class IssueModel : BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("Issue.Number")]
        public string Number { get; set; }

        [BaseEamResourceDisplayName("Issue.Description")]
        public string Description { get; set; }

        [BaseEamResourceDisplayName("Issue.IssueDate")]
        [UIHint("DateTimeNullable")]
        public DateTime? IssueDate { get; set; }

        [BaseEamResourceDisplayName("Issue.Site")]
        public long? SiteId { get; set; }
        public SiteModel Site { get; set; }

        [BaseEamResourceDisplayName("Issue.Store")]
        public long? StoreId { get; set; }
        public StoreModel Store { get; set; }

        [BaseEamResourceDisplayName("Issue.IssueTo")]
        public IssueTo IssueTo { get; set; }

        [BaseEamResourceDisplayName("WorkOrder")]
        public long? WorkOrderId { get; set; }
        public string WorkOrderNumber { get; set; }

        [BaseEamResourceDisplayName("Issue.IsApproved")]
        public bool IsApproved { get; set; }

        [BaseEamResourceDisplayName("Issue.User")]
        public long? UserId { get; set; }
        public UserModel User { get; set; }
    }
}