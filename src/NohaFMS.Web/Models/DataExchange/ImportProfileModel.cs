/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace NohaFMS.Web.Models
{
    [Validator(typeof(ImportProfileValidator))]
    public class ImportProfileModel : BaseEamEntityModel
    {
        public int? FileTypeId { get; set; }

        [BaseEamResourceDisplayName("ImportProfile.Name")]
        public string Name { get; set; }

        [BaseEamResourceDisplayName("EntityType")]
        public string EntityType { get; set; }

        [BaseEamResourceDisplayName("ImportProfile.LastRunStartDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? LastRunStartDateTime { get; set; }

        [BaseEamResourceDisplayName("ImportProfile.LastRunEndDateTime")]
        [UIHint("DateTimeNullable")]
        public DateTime? LastRunEndDateTime { get; set; }

        [BaseEamResourceDisplayName("ImportProfile.ImportFileName")]
        public string ImportFileName { get; set; }
        public long? ImportFileId { get; set; }

        [BaseEamResourceDisplayName("ImportProfile.LogFileName")]
        public string LogFileName { get; set; }
    }
}