/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core.Domain;
using NohaFMS.Services;
using NohaFMS.Web.Extensions;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Framework.Filters;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Models;
using System.Web.Mvc;

namespace NohaFMS.Web.Controllers
{
    public class SettingController : BaseController
    {
        #region Fields

        private readonly ISettingService _settingService;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Constructors

        public SettingController(ISettingService settingService,
            ILocalizationService localizationService)
        {
            this._settingService = settingService;
            this._localizationService = localizationService;
        }

        #endregion

        #region Methods

        [BaseEamAuthorize(PermissionNames = "Setting.GeneralSettings.Read")]
        public ActionResult General()
        {
            var generalSettings = _settingService.LoadSetting<GeneralSettings>();
            var model = generalSettings.ToModel();
            return View(model);
        }

        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "Setting.GeneralSettings.Create,Setting.GeneralSettings.Update")]
        public ActionResult General(GeneralSettingsModel model)
        {
            var generalSettings = model.ToEntity();
            _settingService.SaveSetting(generalSettings);
            SuccessNotification(_localizationService.GetResource("Record.Saved"));
            return new NullJsonResult();
        }

        #endregion
    }
}