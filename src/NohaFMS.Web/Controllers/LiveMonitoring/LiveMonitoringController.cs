using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Framework.Session;
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

using NohaFMS.Web.Models.LiveMonitoring;
using System.Configuration;

namespace NohaFMS.Web.Controllers
{
    public class LiveMonitoringController : BaseController
    {

        #region Fields
        private readonly IRepository<LiveMonitoring> _LiveMonitoringRepository;
        private readonly IRepository<Config> _configRepository;
        private readonly IConfigService _configService;
        private readonly IUserActivityService _userActivityService;
        private readonly ILiveMonitoringServices _liveMonitoringService;
        private readonly IEntityAttributeService _entityAttributeService;
        //private readonly ISettingService _settingService;
        //private readonly IDateTimeHelper _dateTimeHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;

        #endregion


        #region Constructors

        public LiveMonitoringController
            (
            IRepository<LiveMonitoring> liveMonitoringRepository,

            ILiveMonitoringServices liveMonitoringServices,
            IEntityAttributeService entityAttributeService,
            IUserActivityService userActivityService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            HttpContextBase httpContext,
            IWorkContext workContext,
            IDbContext dbContext

            )

        {
            this._LiveMonitoringRepository = liveMonitoringRepository;
            this._userActivityService = userActivityService;
            this._localizationService = localizationService;
            this._liveMonitoringService = liveMonitoringServices;
            this._entityAttributeService = entityAttributeService;
            this._permissionService = permissionService;
            this._httpContext = httpContext;
            this._workContext = workContext;
            this._dbContext = dbContext;
        }
        
        #endregion
        #region Utilities

        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            //var LiveNameFilter = new FieldModel
            //{
            //    DisplayOrder = 1,
            //    Name = "LiveName",
            //    ResourceKey = "LiveMonitoring.LiveName",
            //    DbColumn = "LiveMonitoring.LiveName",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false
            //};
            //model.Filters.Add(LiveNameFilter);

            //var BranchNameFilter = new FieldModel
            //{
            //    DisplayOrder = 2,
            //    Name = "BranchName",
            //    ResourceKey = "LiveMonitoring.BranchName",
            //    DbColumn = "LiveMonitoring.BranchName",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false
            //};
            //model.Filters.Add(BranchNameFilter);

            //var BranchCodeFilter = new FieldModel
            //{
            //    DisplayOrder = 3,
            //    Name = "BranchCode",
            //    ResourceKey = "LiveMonitoring.BranchCode",
            //    DbColumn = "LiveMonitoring.BranchCode",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false
            //};
            //model.Filters.Add(BranchCodeFilter);
            //var CityNameFilter = new FieldModel
            //{
            //    DisplayOrder = 4,
            //    Name = "CityName",
            //    ResourceKey = "LiveMonitoring.CityName",
            //    DbColumn = "LiveMonitoring.CityName",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false
            //};
            //model.Filters.Add(CityNameFilter);

            //var ErrorFilter = new FieldModel
            //{
            //    DisplayOrder = 5,
            //    Name = "Error",
            //    ResourceKey = "ChequeClearing.Error",
            //    DbColumn = "LiveMonitoring.Error",
            //    ControlType = FieldControlType.DropDownList,
            //    DataType = FieldDataType.Boolean,
            //    DataSource = FieldDataSource.MVC,
            //    MvcAction = "Error",
            //    MvcController = "Common",
            //    IsRequiredField = false,
            //    Operator = FieldOperatorType.eq

            //};
            //model.Filters.Add(ErrorFilter);

            //var HubCodeFilter = new FieldModel
            //{
            //    DisplayOrder = 6,
            //    Name = "HubCode",
            //    ResourceKey = "ChequeClearing.HubCode",
            //    DbColumn = "LiveMonitoring.HubCode",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false,
            //    //Operator = FieldOperatorType.eq
            //};
            //model.Filters.Add(HubCodeFilter);
            //var ReturnreasoneFilter = new FieldModel
            //{
            //    DisplayOrder = 7,
            //    Name = "Returnreasone",
            //    ResourceKey = "ChequeClearing.Returnreasone",
            //    DbColumn = "LiveMonitoring.Returnreasone",
            //    ControlType = FieldControlType.DropDownList,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.MVC,
            //    MvcAction = "Returnreasone",
            //    MvcController = "Common",
            //    IsRequiredField = false,
            //    Operator = FieldOperatorType.eq

            //};
            //model.Filters.Add(ReturnreasoneFilter);
           
            return model;
        }
        private SearchModel BuildSearch()
        {
            var model = new SearchModel();
          
            return model;
        }
        #endregion

        #region LiveMonitoring

        // [BaseEamAuthorize(PermissionNames = "Monitoring.ChequeDeposit.Read")]
        public ActionResult List()
        {
         
            //Image newImage = Image.FromFile("E:\\Teknoloje 2021 working\\ibcspresentationdemo\\Sample Data Files and Images_1\\0110001051007102020CLG_Images\\112100004F.jpg");
            //var img=  Directory.GetCurrentDirectory() + "E:\\Teknoloje 2021 working\\ibcspresentationdemo\\Sample Data Files and Images_1\\0110001051007102020CLG_Images\\112100004F.jpg";
            //var files = Directory.GetFiles(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images");
            //string relativePath = ConfigurationManager.AppSettings["CLGPath"];
            var model = _httpContext.Session[SessionKey.LiveMonitoringSearchModel] as SearchModel;
            //  If not exist, build search model
            if (model == null)
            {
                model = BuildSearchModel();
                //session save
               _httpContext.Session[SessionKey.LiveMonitoringSearchModel] = model;
            }
            
            return View(model);

        }

        [HttpPost]
        //[BaseEamAuthorize(PermissionNames = "Monitoring.ChequeDeposit.Read")]
        public ActionResult List(DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //UserActivityLog
            _liveMonitoringService.MonitoringActivityFlowlog(_workContext.CurrentUser.Id, "User[" + _workContext.CurrentUser.Name + "] Monitoring Live-Monitoring List");
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Live Monitoring");

            var model = _httpContext.Session[SessionKey.LiveMonitoringSearchModel] as SearchModel;
            if (model == null)
                model = BuildSearchModel();
            else
                model.ClearValues();
            //validate
            var errorFilters = model.Validate(searchValues);
            foreach (var filter in errorFilters)
            {
                ModelState.AddModelError(filter.Name, _localizationService.GetResource(filter.ResourceKey + ".Required"));
            }
            if (ModelState.IsValid)
            {

                //session update
                //model.Update(searchValues);
                //_httpContext.Session[SessionKey.LiveMonitoringSearchModel] = model;

              //  List<LiveMonitoringModel> liveMonitoringMod = new List<LiveMonitoringModel>();

                PagedResult<LiveMonitoring> data = _liveMonitoringService.GetLiveMonitoring(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                
                //var datas = _liveMonitoringService.GetAllAssetsByParentId(true);

                long userid = this._workContext.CurrentUser.Id;
                // var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in data.Result)
                {
                    var mod = new LiveMonitoring();

                    mod.Id = r.Id;
                    mod.LiveName = r.LiveName;
                    mod.BranchName = r.BranchName;
                    mod.BranchCode = r.BranchCode;
                    mod.CityName = r.CityName;                                     
                }

                var timer =int.Parse(ConfigurationManager.AppSettings["timerLiveMonitoring"]);

                var gridModel = new DataSourceResult
                {
                    
                    Data = data.Result.OrderByDescending(a=>a.Id),//  liveMonitoringMod.OrderByDescending(a => a.Id),
                    Total = data.TotalCount
                };
                return new JsonResult
                {
                    Data = gridModel
                };
            }
           

            return Json(new { Errors = ModelState.SerializeErrors() });

        }

        //TimeSpan timer = new System.Threading.Timer(
        //    e => List(),
        //    null,
        //    TimeSpan.Zero,
        //    TimeSpan.FromMinutes(1));

        public static byte[] ImageToBinary(string imagePath)
        {
            FileStream fileStream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            byte[] buffer = new byte[fileStream.Length];
            fileStream.Read(buffer, 0, (int)fileStream.Length);
            fileStream.Close();
            return buffer;
        }

        public byte[] imgU { get; set; }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]



        

        public ActionResult CallBacksave(LiveMonitoringModel model)
        {

            var resultt = _LiveMonitoringRepository.GetById(model.Id);

            _LiveMonitoringRepository.Update(resultt);


            this._dbContext.SaveChanges();

            //notification
            //SuccessNotification(_localizationService.GetResource("Call Back Done Seccessfully").ToUpper());
            SuccessNotification("Call Back Successfully Forwarded");
            // return new NullJsonResult();
            return RedirectToAction("Edit", "ChequeDeposit", new { id = model.Id });

        }
        public ActionResult CallBack()
        {
            var mode = _httpContext.Session[SessionKey.LiveMonitoringSearchModel] as SearchModel;
            //If not exist, build search model
            if (mode == null)
            {
                mode = BuildSearch();
                //session save
                _httpContext.Session[SessionKey.LiveMonitoringSearchModel] = mode;
            }


            return View(mode);
        }



        #endregion

        public ActionResult create()
        {
            var livemonitory = new LiveMonitoring { IsNew = true };
            _LiveMonitoringRepository.InsertAndCommit(livemonitory);
            //_cityRepository.InsertAndCommit(city);
            return Json(new { Id = livemonitory.Id });
            //return View();
        }

    }
}