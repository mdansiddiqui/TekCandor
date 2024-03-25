using NohaFMS.Core.Domain;
using NohaFMS.Web.Framework;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Validators;
using FluentValidation.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace NohaFMS.Web.Models.LiveMonitoring
{
    public class LiveMonitoringModel: BaseEamEntityModel
    {
        [BaseEamResourceDisplayName("LiveName")]
        public string LiveName { get; set; }
        [BaseEamResourceDisplayName("BranchCode")]
        public string BranchCode { get; set; }
        [BaseEamResourceDisplayName("BranchName")]
        public string BranchName { get; set; }
        [BaseEamResourceDisplayName("CityName")]
        public string CityName { get; set; }

    }
}