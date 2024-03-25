/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using NohaFMS.Services;
using NohaFMS.Web.Framework.Controllers;
using NohaFMS.Web.Framework.Mvc;
using NohaFMS.Web.Framework.CustomField;
using NohaFMS.Web.Framework.Session;
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NohaFMS.Web.Framework.Filters;
using System.IO;
using System;
using System.Collections;
using System.Configuration;
using System.Globalization;
using System.Net.Mail;
using System.Net;

namespace NohaFMS.Web
{
    public class ChequeDepositController : BaseController
    {
        #region Fields
        private readonly IRepository<ChequeDepositInformation> _ChequeDepositRepository;
        private readonly IRepository<SecurityGroup> _securityGroupRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<SecurityGroupUser> _securityGroupUserRepository;
        private readonly IChequeDepositServices _chequedepositService;
        private readonly IUserActivityService _userActivityService;
        private readonly IEntityAttributeService _entityAttributeService;
        //private readonly ISettingService _settingService;
        //private readonly IDateTimeHelper _dateTimeHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;
        private readonly DapperContext _dapperContext;
        //private readonly IRepository<ReturnReason> _ReturnReason;



        #endregion

        #region Constructors

        public ChequeDepositController
            (
            IRepository<ChequeDepositInformation> chequeDepositRepository,

            IChequeDepositServices chequeDepositServices,
            IEntityAttributeService entityAttributeService,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            HttpContextBase httpContext,
            IWorkContext workContext,
            IDbContext dbContext,
            IUserActivityService userActivityService

            )

        {
            this._ChequeDepositRepository = chequeDepositRepository;

            this._localizationService = localizationService;
            this._chequedepositService = chequeDepositServices;
            this._entityAttributeService = entityAttributeService;
            this._permissionService = permissionService;
            this._httpContext = httpContext;
            this._workContext = workContext;
            this._dbContext = dbContext;
            this._userActivityService = userActivityService;
        }

        #endregion
        #region Utilities

        private SearchModel BuildSearchModel()
        {
            var model = new SearchModel();
            var DateFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "Date",
                ResourceKey = "ChequeClearing.Date",
                DbColumn = "ChequeDepositInformation.Date",
                Value = DateTime.Now,
                ControlType = FieldControlType.DateTime,
                DataType = FieldDataType.DateTime,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            
            model.Filters.Add(DateFilter);
            var CycleCodeFilter = new FieldModel
            {
                DisplayOrder = 2,
                Name = "CycleCode",
                ResourceKey = "ChequeClearing.CycleCode",
                DbColumn = "ChequeDepositInformation.CycleCode",
                Value = null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.DB,
                DbTable = "Cycle",
                DbTextColumn = "Name",
                DbValueColumn = "Name",
                IsRequiredField = false

            };
            model.Filters.Add(CycleCodeFilter);
            //var ReceiverBranchCodeFilter = new FieldModel
            //{
            //    DisplayOrder = 2,
            //    Name = "ReceiverBranchCode",
            //    ResourceKey = "ReceiverBranch",
            //    DbColumn = "ChequeDepositInformation.ReceiverBranchCode",
            //    Value = null,
            //    ControlType = FieldControlType.TextBox,
            //    DataType = FieldDataType.String,
            //    DataSource = FieldDataSource.None,
            //    IsRequiredField = false
            //};
            //model.Filters.Add(ReceiverBranchCodeFilter);
            var ChequeNumberFilter = new FieldModel
            {
                DisplayOrder = 3,
                Name = "ChequeNumber",
                ResourceKey = "ChequeClearing.ChequeNumber",
                DbColumn = "ChequeDepositInformation.ChequeNumber",
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(ChequeNumberFilter);

            var ErrorFilter = new FieldModel
            {
                DisplayOrder = 4,
                Name = "Error",
                ResourceKey = "ChequeClearing.Error",
                DbColumn = "ChequeDepositInformation.Error",
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.Boolean,
                DataSource = FieldDataSource.MVC,
                MvcAction = "Error",
                MvcController = "Common",
                IsRequiredField = false,
                Operator = FieldOperatorType.eq

            };
            model.Filters.Add(ErrorFilter);

            var HubCodeFilter = new FieldModel
            {
                DisplayOrder = 5,
                Name = "Hub",
                ResourceKey = "ChequeClearing.HubCode",
                DbColumn = "ChequeDepositInformation.HubCode",
                Value = null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.DB,
                DbTable = "Hub",
                DbTextColumn = "Name",
                DbValueColumn = "Code",
                IsRequiredField = false
            };
            model.Filters.Add(HubCodeFilter);
            var ReturnreasoneFilter = new FieldModel
            {
                DisplayOrder = 6,
                Name = "Returnreasone",
                ResourceKey = "ChequeClearing.Returnreasone",
                DbColumn = "ChequeDepositInformation.Returnreasone",
                Value=null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.DB,
                DbTable = "ReturnReason",
                DbTextColumn = "Name",
                DbValueColumn = "Name",
                IsRequiredField = false

            };
            model.Filters.Add(ReturnreasoneFilter);
            var branchFilter = new FieldModel
            {
                DisplayOrder = 7,
                Name = "Branch",
                ResourceKey = "ChequeDepositInfo.Branch",
                DbColumn = "ChequeDepositInformation.ReceiverBranchCode",
                Value = null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.Int64,
                DataSource = FieldDataSource.DB,
                DbTable = "Branch",
                DbTextColumn = "Name",
                DbValueColumn = "Code",
                IsRequiredField = false
            };
            model.Filters.Add(branchFilter);

            var Status = new FieldModel
            {
                DisplayOrder = 8,
                Name = "Status",
                ResourceKey = "ChequeClearing.Status",
                DbColumn = "ChequeDepositInformation.Status",
                Value=null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.DB,
                DbTable = "ChequeDepositInformation",
                DbTextColumn = "status",
                DbValueColumn = "status",
                IsRequiredField = false


            };
            model.Filters.Add(Status);
            var instrumentFilter = new FieldModel
            {
                DisplayOrder = 9,
                Name = "Instrument",
                ResourceKey = "ChequeDepositInfo.InstrumentNo",
                DbColumn = "ChequeDepositInformation.InstrumentNo",
                Value = null,
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.Int64,
                DataSource = FieldDataSource.DB,
                DbTable = "Instruments",
                DbTextColumn = "Name",
                DbValueColumn = "code",
                IsRequiredField = false
            };
            model.Filters.Add(instrumentFilter);
            var niftBranchCodeFilter = new FieldModel
            {
                DisplayOrder = 10,
                Name = "NiftBranchCode",
                ResourceKey = "ChequeClearing.NiftBranchCode",
                DbColumn = "ChequeDepositInformation.NiftBranchCode",
                Value = null,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.String,
                DataSource = FieldDataSource.None,
                IsRequiredField = false
            };
            model.Filters.Add(niftBranchCodeFilter);
            return model;
        }
        private SearchModel BuildSearch()
        {
            var model = new SearchModel();
            var DateFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "Date",
                ResourceKey = "ChequeClearing.Date",
                DbColumn = "ChequeDepositInformation.Date",
                Value = null,
                ControlType = FieldControlType.DateTime,
                DataType = FieldDataType.DateTime,
                DataSource = FieldDataSource.None,
                IsRequiredField = false,
                

            };
            model.Filters.Add(DateFilter);

            var branchFilter = new FieldModel
            {
                DisplayOrder = 2,
                Name = "BranchName",
                ResourceKey = "Branch.Name",
                DbColumn = "Branch.Id",
                Value = null,
                ControlType = FieldControlType.MultiSelectList,
                DataType = FieldDataType.Int64,
                DataSource = FieldDataSource.DB,
                DbTable = "Branch",
                DbTextColumn = "Name",
                DbValueColumn = "Id",
                IsRequiredField = false
            };
            model.Filters.Add(branchFilter);

            var hubFilter = new FieldModel
            {
                DisplayOrder = 3,
                Name = "HubName",
                ResourceKey = "Hub.Name",
                DbColumn = "Hub.Id",
                ControlType = FieldControlType.DropDownList,
                DataType = FieldDataType.Int64,
                DataSource = FieldDataSource.DB,
                DbTable = "Hub",
                DbTextColumn = "Name",
                DbValueColumn = "Id",
                IsRequiredField = false
            };
            model.Filters.Add(hubFilter);
            return model;
        }
        #endregion
        //#region Utilities
        // GET: ChequeDeposit
        //public ActionResult Index()
        //{
        //    return View();
        //}
        #region ChequeDeposit

        // [BaseEamAuthorize(PermissionNames = "Monitoring.ChequeDeposit.Read")]
        public ActionResult List()
        {

            //Image newImage = Image.FromFile("E:\\Teknoloje 2021 working\\ibcspresentationdemo\\Sample Data Files and Images_1\\0110001051007102020CLG_Images\\112100004F.jpg");
            //var img=  Directory.GetCurrentDirectory() + "E:\\Teknoloje 2021 working\\ibcspresentationdemo\\Sample Data Files and Images_1\\0110001051007102020CLG_Images\\112100004F.jpg";
            //var files = Directory.GetFiles(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images");
            //string relativePath = ConfigurationManager.AppSettings["CLGPath"];
            
            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            long userid = this._workContext.CurrentUser.Id;
            string branch = _chequedepositService.GetBranch(userid);
            
            //  If not exist, build search model

            if (model == null)
            {
                model = BuildSearchModel();
                model.Filters[6].Value =  branch;
                //session save
                
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = model;
            }

            return View(model);

        }

        [HttpPost]
        //[BaseEamAuthorize(PermissionNames = "Monitoring.ChequeDeposit.Read")]
        public ActionResult List(DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {

            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Cheque Clearing Transactions");
            
            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            
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
                model.Update(searchValues);

                //SearchFilters
                var fDate = Convert.ToString(model.Filters.ElementAt(0).Value) ;
                var fReceiverBranchCode = model.Filters.ElementAt(1).Value as string;
                var fChequeNumber = model.Filters.ElementAt(2).Value as string;
                var fError = Convert.ToString(model.Filters.ElementAt(3).Value);
                var fHubCode = model.Filters.ElementAt(4).Value as string;
                var fReturnReason = model.Filters.ElementAt(5).Value as string;
                var fBranch =Convert.ToString(model.Filters.ElementAt(6).Value);
                var fStatus = model.Filters.ElementAt(7).Value as string;
                _chequedepositService.searchFilterLogs(
                        fDate,fReceiverBranchCode,
                        fChequeNumber,
                        fError,
                        fHubCode, fReturnReason,fBranch,fStatus);
                
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = model;
                List<ChequeDepositModel> chequeDepositMod = new List<ChequeDepositModel>();
                long userid = this._workContext.CurrentUser.Id;
                
                PagedResult<ChequeDepositInformation> data = _chequedepositService.GetChequeDepositInfo(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);

                //var datas = _chequedepositService.GetAllAssetsByParentId(true);
                // var result = data.Result.Select(x => x.ToModel()).ToList();
                foreach (var r in data.Result)
                {
                    var mod = new ChequeDepositModel();
                    if (userid == 3)
                    {
                        if (r.status == "F")
                        {
                            mod.Id = r.Id;
                            mod.Date = r.Date;
                            mod.SenderBankCode = r.SenderBankCode;
                            mod.ReceiverBranchCode = r.ReceiverBranchCode;
                            mod.ChequeNumber = r.ChequeNumber;
                            mod.AccountNumber = r.AccountNumber;
                            mod.TransactionCode = r.TransactionCode;
                            mod.Amount = r.Amount;
                            mod.status = r.status;
                            mod.Error = r.Error;
                            mod.HubCode = r.HubCode;


                            if (r.status == "F")
                            {
                                mod.status = "Forward to Approval";
                            }

                            mod.Export = r.Export;
                            chequeDepositMod.Add(mod);
                        }
                    }
                    else
                    {

                        mod.Id = r.Id;
                        mod.Date = r.Date;
                        mod.SenderBankCode = r.SenderBankCode;
                        mod.ReceiverBranchCode = r.ReceiverBranchCode;
                        string branchName = _chequedepositService.GetBranchName(userid);
                        string HubCode = _chequedepositService.GetHubCode(mod.ReceiverBranchCode);
                        mod.ReceiverBranchName = branchName;
                        mod.ChequeNumber = r.ChequeNumber;
                        mod.AccountNumber = r.AccountNumber;
                        mod.TransactionCode = r.TransactionCode;
                        mod.Amount = r.Amount;
                        mod.status = r.status;
                        mod.Error = r.Error;
                        mod.HubCode = HubCode;
                        mod.NiftBranchCode = r.NiftBranchCode;
                        mod.InstrumentNo = r.InstrumentNo;
                        string instNum = _chequedepositService.GetInstrumentNum(mod.InstrumentNo);
                        mod.InstrumentNo = instNum;
                        if (r.status == "I")
                        {
                            mod.status = "Invalid";
                        }
                        else if (r.status == "P")
                        {
                            mod.status = "Pending status";
                        }
                        else if (r.status == "V")
                        {
                            mod.status = "Verified";
                        }
                        else if (r.status == "R")
                        {
                            mod.status = "Return";
                        }
                        else if (r.status == "F")
                        {
                            mod.status = "Forward to Approval";
                        }
                        else if (r.status == "C")
                        {
                            mod.status = "Call Back";
                        }
                        mod.Export = r.Export;
                        chequeDepositMod.Add(mod);
                    }
                }

                var gridModel = new DataSourceResult
                {
                    Data = chequeDepositMod.OrderByDescending(a => a.Id),
                    Total = data.TotalCount
                };

                return Json(gridModel, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Errors = ModelState.SerializeErrors() });

        }

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

        [BaseEamAuthorize(PermissionNames = "Monitoring.Import")]

        public ActionResult ImportData(int selectedIds)
        {

            //var image = ImageToBinary(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images\112100004F.jpg");
            //FileStream fileStream = new FileStream(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images\112100004F.jpg", FileMode.Open, FileAccess.Read);
            //byte[] buffer = new byte[fileStream.Length];
            //fileStream.Read(buffer, 0, (int)fileStream.Length);
            //fileStream.Close();
            //imgU = new byte[image.ContentLength];
            //imgr.InputStream.Read(image, 0, imgr.ContentLength);

            string FolderPath = ConfigurationManager.AppSettings["CLGFolderPath"];
            var allfile = Directory.GetFiles(FolderPath);
            try
            {
                if (allfile.Length > 0)
                {
                    foreach (var fileData in allfile)

                    {
                        var hubcode = string.Empty;
                        string CLG_Befor_Import = fileData;
                        FileInfo fi = new FileInfo(CLG_Befor_Import);
                        string justFileName = fi.Name;
                        int leng = justFileName.Count();
                        string[] filename;
                        filename = justFileName.Split('.');
                        var filenm = Convert.ToString(filename[0].Substring(19, filename[0].Length - 19));
                        //if (nm == "CLG") 
                        //{
                        //    var newmn = Convert.ToString(filename[0].Substring(0, filename[0].Length - 15));
                        //     hubcode= Convert.ToString(newmn.Substring(3, newmn.Length -3));

                        //}


                        if (filenm == "CLGHUB")
                        {
                            var newmn = Convert.ToString(filename[0].Substring(0, filename[0].Length - 18));
                            hubcode = Convert.ToString(newmn.Substring(3, newmn.Length - 3));

                        }
                        List<ChequeDepositInformation> inwardClearingDataModel = new List<ChequeDepositInformation>();
                        ArrayList a1 = new ArrayList();
                        using (StreamReader sr = new StreamReader(fileData))
                        {
                            while (sr.Peek() >= 0)
                            {
                                string str;
                                string[] strArray;
                                str = sr.ReadLine();

                                strArray = str.Split('|');
                                if (strArray.Length > 3)
                                {


                                    ChequeDepositInformation modList = new ChequeDepositInformation();
                                    modList.Date = DateTime.Now;
                                    modList.CycleCode = strArray[1];
                                    modList.CityCode = (strArray[2]);
                                    modList.serialNo = (strArray[3]);
                                    modList.SenderBankCode = (strArray[4]);
                                    modList.SenderBranchCode = (strArray[5]);
                                    modList.ReceiverBankCode = (strArray[6]);
                                    modList.ReceiverBranchCode = (strArray[7]);
                                    modList.ChequeNumber = (strArray[8]);
                                    modList.AccountNumber = (strArray[9]);
                                    modList.SequenceNumber = (strArray[10]);
                                    modList.TransactionCode = (strArray[11]);
                                    modList.Amount = Convert.ToDecimal(strArray[12]);
                                    modList.IQATag = (strArray[13]);
                                    modList.DocumentSkew = (strArray[14]);
                                    modList.Piggyback = (strArray[15]);
                                    modList.ImageToolight = (strArray[16]);
                                    modList.HorizontalStreaks = (strArray[17]);
                                    modList.BelowMinimumCompressedImageSize = (strArray[18]);
                                    modList.AboveMaximumCompressedImageSize = (strArray[19]);
                                    modList.UndersizeImage = (strArray[20]);
                                    modList.FoldedorTornDocumentCorners = (strArray[21]);
                                    modList.FoldedOrTornDocumentEdges = (strArray[22]);
                                    modList.FramingError = (strArray[23]);
                                    modList.OversizeImage = (strArray[24]);
                                    modList.ImageTooDark = (strArray[25]);
                                    modList.FrontRearDimensionMismatch = (strArray[26]);
                                    modList.CarbonStrip = (strArray[27]);
                                    modList.OutOfFocus = (strArray[28]);
                                    modList.QRCodeMatch = (strArray[29]);
                                    modList.UV = (strArray[30]);
                                    modList.MICRPresent = (strArray[31]);
                                    modList.StandardCheque = (strArray[32]);
                                    modList.InstrumentDuplicate = (strArray[33]);
                                    modList.AverageChequeAmount = Convert.ToDecimal(strArray[34]);
                                    modList.TotalChequesCount = (strArray[35]);
                                    modList.TotalChequesReturnCount = (strArray[36]);
                                    modList.CaptureAtNIFT_Branch = Convert.ToString(strArray[37]);
                                    modList.HubCode = hubcode;
                                    modList.Callback = false;
                                    modList.status = "P";
                                    modList.Importtime = DateTime.Now;

                                    int counterroe = 0;
                                    if (modList.IQATag == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.DocumentSkew = modList.DocumentSkew;
                                    if (modList.DocumentSkew == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.Piggyback = modList.Piggyback;
                                    if (modList.Piggyback == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    //  modList.ImageToolight = modList.ImageToolight;
                                    if (modList.ImageToolight == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.HorizontalStreaks = modList.HorizontalStreaks;
                                    if (modList.HorizontalStreaks == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.BelowMinimumCompressedImageSize = modList.BelowMinimumCompressedImageSize;
                                    if (modList.BelowMinimumCompressedImageSize == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.AboveMaximumCompressedImageSize = modList.AboveMaximumCompressedImageSize;
                                    if (modList.AboveMaximumCompressedImageSize == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.UndersizeImage = modList.UndersizeImage;
                                    if (modList.UndersizeImage == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.FoldedorTornDocumentCorners = modList.FoldedorTornDocumentCorners;
                                    if (modList.FoldedorTornDocumentCorners == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.FoldedOrTornDocumentEdges = modList.FoldedOrTornDocumentEdges;
                                    if (modList.FoldedOrTornDocumentEdges == "1")
                                    {
                                        counterroe = 1;

                                    }


                                    if (modList.FramingError == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    //  modList.OversizeImage = modList.OversizeImage;
                                    if (modList.OversizeImage == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.ImageTooDark = modList.ImageTooDark;
                                    if (modList.ImageTooDark == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.FrontRearDimensionMismatch = modList.FrontRearDimensionMismatch;
                                    if (modList.FrontRearDimensionMismatch == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    //  modList.CarbonStrip = modList.CarbonStrip;
                                    if (modList.CarbonStrip == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    //  modList.OutOfFocus = modList.OutOfFocus;
                                    if (modList.OutOfFocus == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.QRCodeMatch = modList.QRCodeMatch;
                                    if (modList.QRCodeMatch == "1")
                                    {
                                        counterroe = 1;

                                    }

                                    // modList.UV = modList.UV;
                                    if (modList.UV == "1")
                                    {
                                        counterroe = 1;

                                    }
                                    if (counterroe > 0)
                                    {
                                        modList.Error = true;
                                    }
                                    // modList.MICRPresent = modList.MICRPresent;
                                    //if (modList.MICRPresent == "1")
                                    //{

                                    //    modList.MICRPresent = "No";
                                    //}

                                    //  modList.StandardCheque = modList.StandardCheque;
                                    //if (modList.StandardCheque == "1")
                                    //{
                                    //    modList.StandardCheque = "No Standard";
                                    //}

                                    // modList.InstrumentDuplicate = modList.InstrumentDuplicate;


                                    //modList.DeferredCheque = (strArray[38]);
                                    //modList.FraudChequeHistory = (strArray[39]);
                                    //modList.Filler = Convert.ToString(strArray[40]);
                                    //var image = ImageToBinary(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images\" +modList.SequenceNumber+"F.jpg");
                                    //modList.imgF = image;
                                    //var imageu = ImageToBinary(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images\" + modList.SequenceNumber + "U.jpg");
                                    //modList.imgU = imageu;
                                    //var imageR = ImageToBinary(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Images\" + modList.SequenceNumber + "R.jpg");
                                    //modList.imgR = imageR;


                                    inwardClearingDataModel.Add(modList);

                                    _ChequeDepositRepository.InsertAndCommit(modList);
                                }




                            }
                        }



                        string FolderPathAfterImport = ConfigurationManager.AppSettings["CLGAfterimportfolder"];
                        string CLG_After_Import = FolderPathAfterImport + justFileName;

                        if (!System.IO.File.Exists(CLG_After_Import))
                        {

                            System.IO.File.Move(CLG_Befor_Import, CLG_After_Import);
                        }
                        // string CLG_After_Import = @"E:\Teknoloje 2021 working\TestFileRemove\CLG2\" + justFileName;

                        //if (!Exists(CLG_After_Import))
                        //{
                        //    //System.IO.File.Delete(path2);
                        //    // Move the file.  
                        //    Move(CLG_Befor_Import, CLG_After_Import);
                        //}
                        //Console.WriteLine("{0} was moved to {1}.", CLG_After_Import, CLG_Befor_Import);

                        //// See if the original exists now.  
                        //if (System.IO.File.Exists(CLG_After_Import))
                        //{
                        //    Console.WriteLine("The original file still exists, which is unexpected.");
                        //}
                        //else
                        //{
                        //    Console.WriteLine("The original file no longer exists, which is expected.");
                        //}
                    }
                    // List<ChequeDepositInformation> inwardClearingDataModel = new List<ChequeDepositInformation>();
                    // ArrayList a1 = new ArrayList();
                    //using (StreamReader sr = new StreamReader(@"E:\Teknoloje 2021 working\ibcspresentationdemo\Sample Data Files and Images_1\0110001051007102020CLG_Data\0110001051005202020CLG.txt"))
                    //{
                    //    while (sr.Peek() >= 0)
                    //    {
                    //        string str;
                    //        string[] strArray;
                    //        str = sr.ReadLine();

                    //        strArray = str.Split('|');
                    //        if (strArray.Length > 3)
                    //        {
                    //            ChequeDepositInformation inwardClearingData = new ChequeDepositInformation();
                    //            inwardClearingData.Date = Convert.ToDateTime(strArray[0]);
                    //            inwardClearingData.CycleCode = (strArray[1]);
                    //            inwardClearingData.CityCode = (strArray[2]);
                    //            inwardClearingData.serialNo = (strArray[3]);
                    //            inwardClearingData.SenderBankCode =(strArray[4]);
                    //            inwardClearingData.SenderBranchCode = (strArray[5]);
                    //            inwardClearingData.ReceiverBankCode = (strArray[6]);
                    //            inwardClearingData.ReceiverBranchCode = (strArray[7]);
                    //            inwardClearingData.ChequeNumber = (strArray[8]);
                    //            inwardClearingData.AccountNumber =(strArray[9]);
                    //            inwardClearingData.SequenceNumber = (strArray[10]);
                    //            inwardClearingData.TransactionCode = (strArray[11]);
                    //            inwardClearingData.Amount = Convert.ToDecimal(strArray[12]);
                    //            inwardClearingData.IQATag = (strArray[13]);
                    //            inwardClearingData.DocumentSkew = (strArray[14]);
                    //            inwardClearingData.Piggyback = (strArray[15]);
                    //            inwardClearingData.ImageToolight = (strArray[16]);
                    //            inwardClearingData.HorizontalStreaks = (strArray[17]);
                    //            inwardClearingData.BelowMinimumCompressedImageSize = (strArray[18]);
                    //            inwardClearingData.AboveMaximumCompressedImageSize = (strArray[19]);
                    //            inwardClearingData.UndersizeImage = (strArray[20]);
                    //            inwardClearingData.FoldedorTornDocumentCorners = (strArray[21]);
                    //            inwardClearingData.FoldedOrTornDocumentEdges = (strArray[22]);
                    //            inwardClearingData.FramingError = (strArray[23]);
                    //            inwardClearingData.OversizeImage = (strArray[24]);
                    //            inwardClearingData.ImageTooDark = (strArray[25]);
                    //            inwardClearingData.FrontRearDimensionMismatch = (strArray[26]);
                    //            inwardClearingData.CarbonStrip = (strArray[27]);
                    //            inwardClearingData.OutOfFocus = (strArray[28]);
                    //            inwardClearingData.QRCodeMatch = (strArray[29]);
                    //            inwardClearingData.UV = (strArray[30]);
                    //            inwardClearingData.MICRPresent = (strArray[31]);
                    //            inwardClearingData.StandardCheque = (strArray[32]);
                    //            inwardClearingData.InstrumentDuplicate = (strArray[33]);
                    //            inwardClearingData.AverageChequeAmount = Convert.ToDecimal(strArray[34]);
                    //            inwardClearingData.TotalChequesCount = (strArray[35]);
                    //            inwardClearingData.TotalChequesReturnCount = (strArray[36]);
                    //            inwardClearingData.CaptureAtNIFT_Branch = Convert.ToString(strArray[37]);
                    //            //inwardClearingData.DeferredCheque = (strArray[38]);
                    //            //inwardClearingData.FraudChequeHistory = (strArray[39]);
                    //            //inwardClearingData.Filler = Convert.ToString(strArray[40]);


                    //            inwardClearingDataModel.Add(inwardClearingData);

                    //            _ChequeDepositRepository.InsertAndCommit(inwardClearingData);
                    //        }




                    //    }
                    //}
                    SuccessNotification(allfile.Length + " __" + " Files Imported Successfully");
                    return new NullJsonResult();
                }

                // return RedirectToAction("List", "ChequeDeposit", new { area = "" });
                else
                {
                    SuccessNotification("You do not have any file in folder");
                    return new NullJsonResult();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void Move(string cLG_Befor_Import, string cLG_After_Import)
        {
            
        }

        private static bool Exists(string cLG_After_Import)
        {
            return true;
        }


        public ActionResult CallBacksave(ChequeDepositModel model)
        {

            var resultt = _ChequeDepositRepository.GetById(model.Id);
            var callbackstatusbefore = resultt.status;

            resultt.Callback = true;
            resultt.status = "C";

            resultt.IsNew = false;

            _ChequeDepositRepository.Update(resultt);

            this._dbContext.SaveChanges();

            //UserActivityLog
            //_userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Call Back Approved of ChequeNumber and AccountNummber are:"+model.ChequeNumber+"-"+model.AccountNumber);

            //notification
            //SuccessNotification(_localizationService.GetResource("Call Back Done Seccessfully").ToUpper());
            SuccessNotification("Call Back Successfully Forwarded");
            // return new NullJsonResult();
            return RedirectToAction("Edit", "ChequeDeposit", new { id = model.Id });

        }
        public ActionResult CallBack()
        {
            var mode = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            //If not exist, build search model
            if (mode == null)
            {
                mode = BuildSearchModel();
                //session save
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = mode;
            }


            return View(mode);
        }

        [HttpPost]
        public ActionResult CallBack(DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Call Back Cheques");

            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;

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
                model.Update(searchValues);

                //SearchFilters
                var fDate = Convert.ToString(model.Filters.ElementAt(0).Value);
                var fReceiverBranchCode = model.Filters.ElementAt(1).Value as string;
                var fChequeNumber = model.Filters.ElementAt(2).Value as string;
                var fError = Convert.ToString(model.Filters.ElementAt(3).Value);
                var fHubCode = model.Filters.ElementAt(4).Value as string;
                var fReturnReason = model.Filters.ElementAt(5).Value as string;
                var fBranch = Convert.ToString(model.Filters.ElementAt(6).Value);
                var fStatus = model.Filters.ElementAt(7).Value as string;
                _chequedepositService.searchFilterLogs(
                        fDate, fReceiverBranchCode,
                        fChequeNumber,
                        fError,
                        fHubCode, fReturnReason, fBranch, fStatus);

                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = model;
                List<ChequeDepositModel> chequeDepositMod = new List<ChequeDepositModel>();
                long userid = this._workContext.CurrentUser.Id;

                PagedResult<ChequeDepositInformation> data = _chequedepositService.GetAllAssetsByParentId(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);
                foreach (var r in data.Result)
                {
                    var mod = new ChequeDepositModel();
                    mod.Id = r.Id;
                    mod.Date = r.Date;
                    mod.SenderBankCode = r.SenderBankCode;
                    mod.ReceiverBranchCode = r.ReceiverBranchCode;
                    string branchName = _chequedepositService.GetBranchName(userid);
                    string HubCode = _chequedepositService.GetHubCode(mod.ReceiverBranchCode);
                    mod.ReceiverBranchName = branchName;
                    mod.ChequeNumber = r.ChequeNumber;
                    mod.AccountNumber = r.AccountNumber;
                    mod.TransactionCode = r.TransactionCode;
                    mod.Amount = r.Amount;
                    // mod.status = r.status;
                    mod.Error = r.Error;
                    mod.HubCode = HubCode;
                    mod.Callback = r.Callback;
                    mod.Callbacksend = r.Callbacksend;
                    if (r.status == "I")
                    {
                        mod.status = "Invalid";
                    }
                    else if (r.status == "P")
                    {
                        mod.status = "Pending status";
                    }
                    else if (r.status == "V")
                    {
                        mod.status = "Verified";
                    }
                    else if (r.status == "R")
                    {
                        mod.status = "Return";
                    }
                    else if (r.status == "F")
                    {
                        mod.status = "Forward to Approvel";
                    }
                    else if (r.status == "C")
                    {
                        mod.status = "Call Back";
                    }
                    mod.Export = r.Export;
                    chequeDepositMod.Add(mod);
                }

                var gridModel = new DataSourceResult
                {
                    Data = chequeDepositMod.OrderByDescending(a => a.Id),
                    Total = data.TotalCount
                };

                return Json(gridModel, JsonRequestBehavior.AllowGet);
            }
            return Json(new { Errors = ModelState.SerializeErrors() });


        }

        public ActionResult CallBackReturn()
        {
            var mode = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            //If not exist, build search model
            if (mode == null)
            {
                mode = BuildSearch();
                //session save
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = mode;
            }


            return View(mode);
        }

        [HttpPost]
         
        public ActionResult CallBackReturn(string dateto, string datefrom, DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "CallBack/Return Transactions");
            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;

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


            {
                if (ModelState.IsValid)
                {
                    try
                    {

                        List<ChequeDepositModel> chequeDepositMod = new List<ChequeDepositModel>();


                        PagedResult<ChequeDepositInformation> data = _chequedepositService.GetAllAssetsCallBackReturn(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);


                        // var result = data.Result.Select(x => x.ToModel()).ToList();
                        long userid = this._workContext.CurrentUser.Id;
                        foreach (var r in data.Result)
                        {
                            var mod = new ChequeDepositModel();
                            mod.Id = r.Id;
                            mod.Date = r.Date;
                            mod.SenderBankCode = r.SenderBankCode;
                            mod.ReceiverBranchCode = r.ReceiverBranchCode;
                            string branchName = _chequedepositService.GetBranchName(userid);
                            string HubCode = _chequedepositService.GetHubCode(mod.ReceiverBranchCode);
                            mod.ReceiverBranchName = branchName;
                            mod.ChequeNumber = r.ChequeNumber;
                            mod.AccountNumber = r.AccountNumber;
                            mod.TransactionCode = r.TransactionCode;
                            mod.Amount = r.Amount;
                            // mod.status = r.status;
                            mod.Error = r.Error;
                            mod.HubCode = HubCode;
                            mod.Callback = r.Callback;
                            mod.Callbacksend = r.Callbacksend;
                            if (r.status == "I")
                            {
                                mod.status = "Invalid";
                            }
                            else if (r.status == "P")
                            {
                                mod.status = "Pending status";
                            }
                            else if (r.status == "V")
                            {
                                mod.status = "Verified";
                            }
                            else if (r.status == "R")
                            {
                                mod.status = "Return";
                            }
                            else if (r.status == "F")
                            {
                                mod.status = "Forward to Approvel";
                            }
                            else if (r.status == "C")
                            {
                                mod.status = "Call Back";
                            }
                            mod.Export = r.Export;
                            chequeDepositMod.Add(mod);
                        }

                        var gridModel = new DataSourceResult
                        {
                            Data = chequeDepositMod.OrderByDescending(a => a.Id),
                            Total = data.TotalCount
                        };
                        return new JsonResult
                        {
                            Data = gridModel,

                        };

                    }

                    catch (Exception ex)
                    {
                        throw ex;

                    }
                }

                return Json(new { Errors = ModelState.SerializeErrors() });
            }
        }

        public ActionResult CallBackApprove()
        {
            var mode = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            //If not exist, build search model
            if (mode == null)
            {
                mode = BuildSearchModel();
                //session save
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = mode;
            }


            return View(mode);
        }

        [HttpPost]
         
        public ActionResult CallBackApprove(string dateto, string datefrom, DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Approve Transactions");
            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
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
                model.Update(searchValues);
                try
                {

                    List<ChequeDepositModel> chequeDepositMod = new List<ChequeDepositModel>();


                    PagedResult<ChequeDepositInformation> data = _chequedepositService.GetAllAssetsApproved(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);


                    // var result = data.Result.Select(x => x.ToModel()).ToList();
                    long userid = this._workContext.CurrentUser.Id;
                    foreach (var r in data.Result)
                    {
                        var mod = new ChequeDepositModel();
                        mod.Id = r.Id;
                        mod.Date = r.Date;
                        mod.SenderBankCode = r.SenderBankCode;
                        mod.ReceiverBranchCode = r.ReceiverBranchCode;
                        string branchName = _chequedepositService.GetBranchName(userid);
                        string HubCode = _chequedepositService.GetHubCode(mod.ReceiverBranchCode);
                        mod.ChequeNumber = r.ChequeNumber;
                        mod.AccountNumber = r.AccountNumber;
                        mod.TransactionCode = r.TransactionCode;
                        mod.Amount = r.Amount;
                        // mod.status = r.status;
                        mod.Error = r.Error;
                        mod.HubCode = HubCode;
                        mod.Callback = r.Callback;
                        mod.Callbacksend = r.Callbacksend;
                        if (r.status == "I")
                        {
                            mod.status = "Invalid";
                        }
                        else if (r.status == "P")
                        {
                            mod.status = "Pending status";
                        }
                        else if (r.status == "V")
                        {
                            mod.status = "Approved";
                        }
                        else if (r.status == "R")
                        {
                            mod.status = "Return";
                        }
                        else if (r.status == "F")
                        {
                            mod.status = "Forward to Approvel";
                        }
                        else if (r.status == "C")
                        {
                            mod.status = "Call Back";
                        }
                        mod.Export = r.Export;
                        chequeDepositMod.Add(mod);
                    }

                    var gridModel = new DataSourceResult
                    {
                        Data = chequeDepositMod.OrderByDescending(a => a.Id),
                        Total = data.TotalCount
                    };
                    return new JsonResult
                    {
                        Data = gridModel,

                    };

                }

                catch (Exception ex)
                {
                    throw ex;

                }

            }
            return Json(new { Errors = ModelState.SerializeErrors() });
        }

        public ActionResult Authorizer()
        {
            var mode = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;
            //If not exist, build search model
            if (mode == null)
            {
                mode = BuildSearchModel();
                //session save
                _httpContext.Session[SessionKey.ChequeDepositSearchModel] = mode;
            }


            return View(mode);
        }

        [HttpPost]
      
        public ActionResult Authorizer(string dateto, string datefrom, DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Autorizer Transactions");
            var model = _httpContext.Session[SessionKey.ChequeDepositSearchModel] as SearchModel;

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
                model.Update(searchValues);
                try
                {

                    List<ChequeDepositModel> chequeDepositMod = new List<ChequeDepositModel>();


                    PagedResult<ChequeDepositInformation> data = _chequedepositService.GetChequeDepositInfo(model.ToExpression(), model.ToParameters(), command.Page - 1, command.PageSize, sort);


                    // var result = data.Result.Select(x => x.ToModel()).ToList();
                    long userid = this._workContext.CurrentUser.Id;
                    foreach (var r in data.Result)
                    {
                        var mod = new ChequeDepositModel();
                        mod.Id = r.Id;
                        mod.Date = r.Date;
                        mod.SenderBankCode = r.SenderBankCode;
                        mod.ReceiverBranchCode = r.ReceiverBranchCode;
                        string branchName = _chequedepositService.GetBranchName(userid);
                        string HubCode = _chequedepositService.GetHubCode(mod.ReceiverBranchCode);
                        mod.ReceiverBranchName = branchName;
                        mod.ChequeNumber = r.ChequeNumber;
                        mod.AccountNumber = r.AccountNumber;
                        mod.TransactionCode = r.TransactionCode;
                        mod.Amount = r.Amount;
                        // mod.status = r.status;
                        mod.Error = r.Error;
                        mod.HubCode = HubCode;
                        mod.Callback = r.Callback;
                        mod.Callbacksend = r.Callbacksend;
                        if (r.status == "I")
                        {
                            mod.status = "Invalid";
                        }
                        else if (r.status == "P")
                        {
                            mod.status = "Pending status";
                        }
                        else if (r.status == "V")
                        {
                            mod.status = "Approved";
                        }
                        else if (r.status == "R")
                        {
                            mod.status = "Return";
                        }
                        else if (r.status == "F")
                        {
                            mod.status = "Forward to Approval";
                        }
                        else if (r.status == "C")
                        {
                            mod.status = "Call Back";
                        }
                        mod.Export = r.Export;
                        chequeDepositMod.Add(mod);
                    }

                    var gridModel = new DataSourceResult
                    {
                        Data = chequeDepositMod.OrderByDescending(a => a.Id),
                        Total = data.TotalCount
                    };
                    return new JsonResult
                    {
                        Data = gridModel,

                    };

                }

                catch (Exception ex)
                {
                    throw ex;

                }

            }
            return Json(new { Errors = ModelState.SerializeErrors() });
            {
                

            }
        }

        [HttpPost]
        [BaseEamAuthorize(PermissionNames = "Report.Report.Delete")]
        public ActionResult ResetStatus(ICollection<long> selectedIds)
        {
            foreach (long id in selectedIds)
            {
                var data = _ChequeDepositRepository.GetById(id);
                if (data.status == "V")
                {
                    data.status = "P";
                }
                //update attributes
                _ChequeDepositRepository.Update(data);

                //commit all changes
                this._dbContext.SaveChanges();
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, 
                    $"Status has been Changed from 'V' to 'P' for Cheque bearing ChequeNumber and AccountNumber:{data.ChequeNumber}-{data.AccountNumber}");

                SuccessNotification("Records Reversed");

                //notification
                if (ModelState.IsValid)
                {
                    return new NullJsonResult();

                }
                else
                {
                    return Json(new { Errors = ModelState.SerializeErrors() });
                }

            }
            return Json(new { Errors = ModelState.SerializeErrors() });


        }
        
        public ActionResult Edit(long id)
        {
            //UserActivityLogs
//            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Edit Cheque where Id is=" + id);

            //_chequedepositService.MonitoringActivityFlowlog(_workContext.CurrentUser.Id, "Cheque Clearing Transaction---> Editing Record->" + id);
            //_chequedepositService.ChequeDepositEditBtnLogs(id);


            ChequeDepositModel modList = new ChequeDepositModel();
            int counterroe = 0;
            var chequeDeposit = _ChequeDepositRepository.GetById(id);
            modList.Id = chequeDeposit.Id;
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.Date = chequeDeposit.Date;
            modList.CycleCode = chequeDeposit.CycleCode;
            modList.CityCode = chequeDeposit.CityCode;
            modList.serialNo = chequeDeposit.serialNo;
            modList.SenderBankCode = chequeDeposit.SenderBankCode;
            modList.SenderBranchCode = chequeDeposit.SenderBranchCode;
            modList.ReceiverBankCode = chequeDeposit.ReceiverBankCode;
            modList.ReceiverBranchCode = chequeDeposit.ReceiverBranchCode;
            modList.ChequeNumber = chequeDeposit.ChequeNumber;
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.SequenceNumber = chequeDeposit.SequenceNumber;
            modList.TransactionCode = chequeDeposit.TransactionCode;
            modList.Amount = chequeDeposit.Amount;
            modList.chequeDate = chequeDeposit.chequeDate?.ToString("dd/MM/yyyy");
            modList.AcccountTitle = "MUHAMMAD FAROOQ";
            modList.AvailableBalance = 2150000;
            modList.LedgerBalance = "217,108.06";
            modList.Remarks = chequeDeposit.Remarks;
            if (chequeDeposit.IQATag == "1")
            {

                counterroe += 1;
                modList.IQATag = "Not Ok";
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-IQA Tag is not Ok," + Environment.NewLine;


            }
            else if (chequeDeposit.IQATag == "2")
            {
                modList.IQATag = "Ok";
            }
            // modList.DocumentSkew = chequeDeposit.DocumentSkew;
            if (chequeDeposit.DocumentSkew == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Document Skew is not Ok," + Environment.NewLine;
                modList.DocumentSkew = "Not Ok";


            }
            else if (chequeDeposit.DocumentSkew == "2")
            {

                modList.DocumentSkew = "Ok";
            }
            // modList.Piggyback = chequeDeposit.Piggyback;
            if (chequeDeposit.Piggyback == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Piggy back is not Ok,  " + Environment.NewLine;
                modList.Piggyback = "Not Ok";



            }
            else if (chequeDeposit.Piggyback == "2")
            {

                modList.Piggyback = "Ok";
            }
            //  modList.ImageToolight = chequeDeposit.ImageToolight;
            if (chequeDeposit.ImageToolight == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Light is not Ok,  " + Environment.NewLine;
                modList.ImageToolight = "Not Ok";

            }
            else if (chequeDeposit.ImageToolight == "2")
            {
                modList.ImageToolight = "Ok";
            }
            // modList.HorizontalStreaks = chequeDeposit.HorizontalStreaks;
            if (chequeDeposit.HorizontalStreaks == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Horizontal Streaks is not Ok,  " + Environment.NewLine;
                modList.HorizontalStreaks = "Not Ok";
            }
            else if (chequeDeposit.HorizontalStreaks == "2")
            {
                modList.HorizontalStreaks = "Ok";
            }
            // modList.BelowMinimumCompressedImageSize = chequeDeposit.BelowMinimumCompressedImageSize;
            if (chequeDeposit.BelowMinimumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Below Minimum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.BelowMinimumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.BelowMinimumCompressedImageSize == "2")
            {

                modList.BelowMinimumCompressedImageSize = "Ok";
            }
            // modList.AboveMaximumCompressedImageSize = chequeDeposit.AboveMaximumCompressedImageSize;
            if (chequeDeposit.AboveMaximumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Above Maximum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.AboveMaximumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.AboveMaximumCompressedImageSize == "2")
            {
                modList.AboveMaximumCompressedImageSize = "Ok";
            }
            // modList.UndersizeImage = chequeDeposit.UndersizeImage;
            if (chequeDeposit.UndersizeImage == "1")
            {
                counterroe = 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Under Size Image is not Ok,  " + Environment.NewLine;
                modList.UndersizeImage = "Not Ok";
            }
            else if (chequeDeposit.UndersizeImage == "2")
            {
                modList.UndersizeImage = "Ok";
            }
            // modList.FoldedorTornDocumentCorners = chequeDeposit.FoldedorTornDocumentCorners;
            if (chequeDeposit.FoldedorTornDocumentCorners == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded or Torn Document Corners is not Ok,  " + Environment.NewLine;
                modList.FoldedorTornDocumentCorners = "Not Ok";
            }
            else if (chequeDeposit.FoldedorTornDocumentCorners == "2")
            {
                modList.FoldedorTornDocumentCorners = "Ok";
            }
            // modList.FoldedOrTornDocumentEdges = chequeDeposit.FoldedOrTornDocumentEdges;
            if (chequeDeposit.FoldedOrTornDocumentEdges == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded Or Torn Document Edges is not Ok,  " + Environment.NewLine;
                modList.FoldedOrTornDocumentEdges = "Not Ok";
            }
            else if (chequeDeposit.FoldedOrTornDocumentEdges == "2")
            {
                modList.FoldedOrTornDocumentEdges = "Ok";
            }
            // modList.FramingError = chequeDeposit.FramingError;
            if (chequeDeposit.FramingError == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Framing Error is not Ok,  " + Environment.NewLine;
                modList.FramingError = "Not Ok";
            }
            else if (chequeDeposit.FramingError == "2")
            {
                modList.FramingError = "Ok";
            }
            //  modList.OversizeImage = chequeDeposit.OversizeImage;

            if (chequeDeposit.OversizeImage == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Over size Image is not Ok,  " + Environment.NewLine;
                modList.OversizeImage = "Not Ok";
            }
            else if (chequeDeposit.OversizeImage == "2")
            {
                modList.OversizeImage = "Ok";
            }
            // modList.ImageTooDark = chequeDeposit.ImageTooDark;
            if (chequeDeposit.ImageTooDark == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Dark is not Ok,  " + Environment.NewLine;
                modList.ImageTooDark = "Not Ok";
            }
            else if (chequeDeposit.ImageTooDark == "2")
            {
                modList.ImageTooDark = "Ok";
            }
            // modList.FrontRearDimensionMismatch = chequeDeposit.FrontRearDimensionMismatch;
            if (chequeDeposit.FrontRearDimensionMismatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Front Rear Dimension Mismatch is not Ok,  " + Environment.NewLine;
                modList.FrontRearDimensionMismatch = "Not Ok";
            }
            else if (chequeDeposit.FrontRearDimensionMismatch == "2")
            {
                modList.FrontRearDimensionMismatch = "Ok";
            }
            //  modList.CarbonStrip = chequeDeposit.CarbonStrip;
            if (chequeDeposit.CarbonStrip == "1")
            {
                counterroe += 1;

                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Carbon Strip is not Ok,  " + Environment.NewLine;
                modList.CarbonStrip = "Not Ok";
            }
            else if (chequeDeposit.CarbonStrip == "2")
            {
                modList.CarbonStrip = "Ok";
            }
            //  modList.OutOfFocus = chequeDeposit.OutOfFocus;
            if (chequeDeposit.OutOfFocus == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Out Of Focus is not Ok,  " + Environment.NewLine;
                modList.OutOfFocus = "Not Ok";
            }
            else if (chequeDeposit.OutOfFocus == "2")
            {
                modList.OutOfFocus = "Ok";
            }
            // modList.QRCodeMatch = chequeDeposit.QRCodeMatch;
            if (chequeDeposit.QRCodeMatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-QR Code Match is not Ok,  " + Environment.NewLine;
                modList.QRCodeMatch = "Not Ok";
            }
            else if (chequeDeposit.QRCodeMatch == "2")
            {
                modList.QRCodeMatch = "Ok";
            }
            // modList.UV = chequeDeposit.UV;
            if (chequeDeposit.UV == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-UV is not Ok,  " + Environment.NewLine;
                modList.UV = "Not Ok";
            }
            else if (chequeDeposit.UV == "2")
            {
                modList.UV = "Ok";
            }
            // modList.MICRPresent = chequeDeposit.MICRPresent;
            if (chequeDeposit.MICRPresent == "1")
            {

                modList.MICRPresent = "No";
            }
            else if (chequeDeposit.MICRPresent == "2")
            {
                modList.MICRPresent = "Yes";
            }
            //  modList.StandardCheque = chequeDeposit.StandardCheque;
            if (chequeDeposit.StandardCheque == "1")
            {
                modList.StandardCheque = "No Standard";
            }
            else if (chequeDeposit.StandardCheque == "2")
            {
                modList.StandardCheque = "Standard";
            }
            // modList.InstrumentDuplicate = chequeDeposit.InstrumentDuplicate;
            if (chequeDeposit.InstrumentDuplicate == "1")
            {
                modList.InstrumentDuplicate = "Duplicate";
            }
            else if (chequeDeposit.InstrumentDuplicate == "2")
            {
                modList.InstrumentDuplicate = "Not Duplicate";
            }
            modList.AverageChequeAmount = chequeDeposit.AverageChequeAmount;
            modList.TotalChequesCount = chequeDeposit.TotalChequesCount;
            modList.TotalChequesReturnCount = chequeDeposit.TotalChequesReturnCount;
            // modList.CaptureAtNIFT_Branch = chequeDeposit.CaptureAtNIFT_Branch;
            if (chequeDeposit.CaptureAtNIFT_Branch == "N")
            {
                modList.CaptureAtNIFT_Branch = "Capture At NIFT";
            }
            else if (chequeDeposit.CaptureAtNIFT_Branch == "B")
            {
                modList.CaptureAtNIFT_Branch = "Capture At Branch";

            }
            if (chequeDeposit.SequenceNumber != null)
            {
                modList.imgF = chequeDeposit.SequenceNumber + "F";
                modList.imgR = chequeDeposit.SequenceNumber + "R";
                modList.imgU = chequeDeposit.SequenceNumber + "U";
            }

            modList.Returnreasone = chequeDeposit.Returnreasone;
            modList.status = chequeDeposit.status;
            modList.Error = chequeDeposit.Error;
            if (modList.Error == true)
            {
                modList.Errors = "Yes";
            }
            else
            {

                modList.Errors = "No";
            }
            if (modList.Export == true)
            {
                modList.Exported = "Yes";
            }
            else
            {
                modList.Exported = "No";
            }
            modList.HubCode = chequeDeposit.HubCode;
            // var model = chequeDeposit.ToModel();


            var status = new List<SelectListItem>();


            status.Add(new SelectListItem()
            {
                Text = "(101) Ammount in word and figure differs",
                Value = " (101) Ammount in word and figure differs",

            });
            status.Add(new SelectListItem()
            {
                Text = "(102) Insufficient funds in drawer’s account",
                Value = "(102) Insufficient funds in drawer’s account",

            });

            status.Add(new SelectListItem()
            {
                Text = "(201) Date is Missing / Invalid",
                Value = "(201) Date is Missing / Invalid",

            });
            status.Add(new SelectListItem()
            {
                Text = "(202) Duplicate instrument / Instrument lodged again in Clearing",
                Value = "(202) Duplicate instrument / Instrument lodged again in Clearing",

            });
            status.Add(new SelectListItem()
            {
                Text = "(301) Closed / Inactive Account",
                Value = "(301) Closed / Inactive Account",

            });
            status.Add(new SelectListItem()
            {
                Text = "(401) Bank’s special crossing required",
                Value = "(401) Bank’s special crossing required",

            });
            status.Add(new SelectListItem()
            {
                Text = "(501) Payment stopped by drawer",
                Value = "(501) Payment stopped by drawer",

            });
            status.Add(new SelectListItem()
            {
                Text = "(601) Alteration on payment instrument requires drawer's signature",
                Value = "(601)  Alteration on payment instrument requires drawer's signature",

            });
            status.Add(new SelectListItem()
            {
                Text = "(604) Signature is unauthorized / differ from specimen on record",
                Value = "(604) Signature is unauthorized / differ from specimen on record",

            });
            status.Add(new SelectListItem()
            {
                Text = "(900) Payment defer for physical instrument review",
                Value = "(900) Payment defer for physical instrument review",

            });
            //UserActivityLogs
            _chequedepositService.ChequeDepositEditBtnLogs(id);

            long userid = this._workContext.CurrentUser.Id;
            TempData[NohaFMS.Web.Framework.Session.SessionKey.TEMP_User_Id] = userid;
            Session[SessionKey.SESSION_ReturnReason_LIST] = status;
            
            return View(modList);
        }
        [HttpPost]
        public ActionResult Edit(ChequeDepositModel model)
        {
            long userid = this._workContext.CurrentUser.Id;
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            ChequeDepositModel mod = new ChequeDepositModel();
            var resultt = _ChequeDepositRepository.GetById(model.Id);
            if (model.status == "V")
            {
                decimal Limit = _chequedepositService.GetLimit(userid);
                if (resultt.Amount > Limit)
                {
                    ErrorNotification("Your limit mismatch");
                    return new NullJsonResult();
                }
            }
            if (model.status == "V")
            {
                if (resultt.Amount < model.AvailableBalance)
                {
                    ErrorNotification("Amount is greater then available balance you can not approve");
                    return new NullJsonResult();
                }
            }

            if (resultt.ChequeNumber.Length < 8 && resultt.ChequeNumber.Length > 8)
            {
                ErrorNotification("Cheque Number must of eight digit");
                return new NullJsonResult();

            }
            if (model.chequeDate!="")
            {
                string dt = model.chequeDate;
                DateTime DT = DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                resultt.chequeDate = DT;
            }
            else {
                resultt.chequeDate = null;
            }
            resultt.Returnreasone = model.Returnreasone;
            resultt.AccountNumber = model.AccountNumber;
            resultt.Remarks = model.Remarks;
            resultt.ChequeNumber = model.ChequeNumber;
            resultt.Export = model.Export;
            resultt.status = model.status;
            resultt.SenderBankCode = model.SenderBankCode;
            resultt.HubCode = model.HubCode;
            resultt.Error = model.Error;
            resultt.ReceiverBranchCode = model.ReceiverBranchCode;
            resultt.TransactionCode = model.TransactionCode;
            if (model.status == "C")
            {
                resultt.Callback = false;
            }
            resultt.IsNew = false;
            if (model.Amount > 100000 && userid != 1)
            {
                SuccessNotification("Forward to Approval");
                resultt.status = "F";
            }
            else
            {
                resultt.status = model.status;
                resultt.Auth = true;
                SuccessNotification("Record Saved Seccessfully");
            }
            //update attributes
            //_entityAttributeService.UpdateEntityAttributes(model.Id, EntityType.ChequeDepositInformation, json);
            _ChequeDepositRepository.Update(resultt);

            //commit all changes
            this._dbContext.SaveChanges();


            //UserActivityLogs
            //_chequedepositService.MonitoringActivityFlowlog(userid, "Call Back Edit Saved Record id-> [" + resultt.Id + "]
            //with MOdified Column(s)"+Environment.NewLine+$"\t [status] = [{resultt.status}]");
            _chequedepositService.ChequeDepositAfterEditBtnLogs(resultt.Id);

            //notification

            return new NullJsonResult();
        }

        [HttpPost]
        public ActionResult Post(ChequeDepositModel model)
        {

            var resultt = _ChequeDepositRepository.GetById(model.Id);


            // resultt = model.ToEntity(resultt);

            //always set IsNew to false when saving

            resultt.Callback = true;
            _ChequeDepositRepository.Update(resultt);

            //commit all changes
            this._dbContext.SaveChanges();
            //UserActivityLogs
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $"" +
                $"Record Posted Successully for ChequeNumber:{resultt.ChequeNumber} AccountNumber;{resultt.AccountNumber}");
            SuccessNotification("Record Posted Seccessfully");

            return new NullJsonResult();

        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        // [BaseEamAuthorize(PermissionNames = "Inventory.Item.Delete")]
        [BaseEamAuthorize(PermissionNames = "Monitoring.Export")]
        public ActionResult ChequeDepositSelected(long? parentId, ICollection<long> selectedIds)
        {
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            string _folderPath = ConfigurationManager.AppSettings["RTNFolderPath"];
            string pipe = "|";
            string[] lines = new string[selectedIds.Count];
            int count = 0;
            var ReceiverBranchCode = string.Empty;
            var ReceiverBankCode = string.Empty;
            var CycleCode = string.Empty;
            var CityCode = string.Empty;




            try
            {
                //var items = new List<ChequeDepositInformation>();
                foreach (long id in selectedIds)
                {


                    var ChequeData = _ChequeDepositRepository.GetById(id);

                    if (ChequeData != null && ChequeData.status == "R")
                    {
                        if (count == 0)
                        {
                            ReceiverBankCode = ChequeData.ReceiverBankCode;
                            ReceiverBranchCode = ChequeData.ReceiverBranchCode;
                            CycleCode = ChequeData.CycleCode.ToString();
                            CityCode = ChequeData.CityCode.ToString();

                        }

                        string line = ChequeData.Date.ToString("dd-MM-yyyy") + "|" + (ChequeData.CycleCode) + "|" + (ChequeData.CityCode) + "|" + (ChequeData.serialNo) + pipe + (ChequeData.SenderBankCode) + pipe + (ChequeData.SenderBranchCode) + pipe + (ChequeData.ReceiverBankCode) + pipe + (ChequeData.ReceiverBranchCode) + pipe + (ChequeData.ChequeNumber) + pipe + (ChequeData.AccountNumber) + pipe + (ChequeData.SequenceNumber) + pipe + (ChequeData.TransactionCode) + pipe + ChequeData.Amount + pipe + ChequeData.status + pipe + (ChequeData.ReceiverBankCode) + pipe + (ChequeData.Returnreasone) + pipe + ChequeData.Filler + pipe + ChequeData.Filler + pipe /*+ Environment.NewLine*/;
                        lines[count] = line;

                        //items.Add(ChequeData);
                        count += 1;

                        var resultt = _ChequeDepositRepository.GetById(id);

                        resultt.Export = true;
                        _entityAttributeService.UpdateEntityAttributes(id, EntityType.ChequeDepositInformation, json);

                        _ChequeDepositRepository.Update(resultt);

                        //commit all changes
                        this._dbContext.SaveChanges();

                    }
                }
                if (count > 0)
                {
                    string fileName = ReceiverBankCode + ReceiverBranchCode + CycleCode + CityCode + DateTime.Today.ToString("MMddyyyy") + "RTN.txt";
                    AppendAllLines(_folderPath + fileName, lines);
                    _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, "Cheque Records Exported");

                            SuccessNotification(count + " __" + " Record Successfully Exported");
                }
                else
                {
                    SuccessNotification("Only Invalid Record will be Export");
                }
                //string endoffile = "EOF";
                //System.IO.File.WriteAllText(@"E:\Teknoloje 2021 working\Test.txt", endoffile);



                return new NullJsonResult();

            }
            catch (Exception ex)
            {
                throw ex;

                // return Json(new { Errors = ModelState.SerializeErrors() });

            }

        }

        private void AppendAllLines(string v, string[] lines)
        {
            throw new NotImplementedException();
        }

        public ActionResult zoomImage(long id)

        {


            ChequeDepositModel modList = new ChequeDepositModel();
            int counterroe = 0;

            var chequeDeposit = _ChequeDepositRepository.GetById(id);
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.Date = chequeDeposit.Date;
            modList.CycleCode = chequeDeposit.CycleCode;
            modList.CityCode = chequeDeposit.CityCode;
            modList.serialNo = chequeDeposit.serialNo;
            modList.SenderBankCode = chequeDeposit.SenderBankCode;
            modList.SenderBranchCode = chequeDeposit.SenderBranchCode;
            modList.ReceiverBankCode = chequeDeposit.ReceiverBankCode;
            modList.ReceiverBranchCode = chequeDeposit.ReceiverBranchCode;
            modList.ChequeNumber = chequeDeposit.ChequeNumber;
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.SequenceNumber = chequeDeposit.SequenceNumber;
            modList.TransactionCode = chequeDeposit.TransactionCode;
            modList.Amount = chequeDeposit.Amount;
            // modList.IQATag = chequeDeposit.IQATag;

            if (chequeDeposit.IQATag == "1")
            {

                counterroe += 1;
                modList.IQATag = "Not Ok";
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-IQA Tag is not Ok," + Environment.NewLine;


            }
            else if (chequeDeposit.IQATag == "2")
            {
                modList.IQATag = "Ok";
            }
            // modList.DocumentSkew = chequeDeposit.DocumentSkew;
            if (chequeDeposit.DocumentSkew == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Document Skew is not Ok," + Environment.NewLine;
                modList.DocumentSkew = "Not Ok";


            }
            else if (chequeDeposit.DocumentSkew == "2")
            {

                modList.DocumentSkew = "Ok";
            }
            // modList.Piggyback = chequeDeposit.Piggyback;
            if (chequeDeposit.Piggyback == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Piggy back is not Ok,  " + Environment.NewLine;
                modList.Piggyback = "Not Ok";



            }
            else if (chequeDeposit.Piggyback == "2")
            {

                modList.Piggyback = "Ok";
            }
            //  modList.ImageToolight = chequeDeposit.ImageToolight;
            if (chequeDeposit.ImageToolight == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Light is not Ok,  " + Environment.NewLine;
                modList.ImageToolight = "Not Ok";

            }
            else if (chequeDeposit.ImageToolight == "2")
            {
                modList.ImageToolight = "Ok";
            }
            // modList.HorizontalStreaks = chequeDeposit.HorizontalStreaks;
            if (chequeDeposit.HorizontalStreaks == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Horizontal Streaks is not Ok,  " + Environment.NewLine;
                modList.HorizontalStreaks = "Not Ok";
            }
            else if (chequeDeposit.HorizontalStreaks == "2")
            {
                modList.HorizontalStreaks = "Ok";
            }
            // modList.BelowMinimumCompressedImageSize = chequeDeposit.BelowMinimumCompressedImageSize;
            if (chequeDeposit.BelowMinimumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Below Minimum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.BelowMinimumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.BelowMinimumCompressedImageSize == "2")
            {

                modList.BelowMinimumCompressedImageSize = "Ok";
            }
            // modList.AboveMaximumCompressedImageSize = chequeDeposit.AboveMaximumCompressedImageSize;
            if (chequeDeposit.AboveMaximumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Above Maximum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.AboveMaximumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.AboveMaximumCompressedImageSize == "2")
            {
                modList.AboveMaximumCompressedImageSize = "Ok";
            }
            // modList.UndersizeImage = chequeDeposit.UndersizeImage;
            if (chequeDeposit.UndersizeImage == "1")
            {
                counterroe = 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Under Size Image is not Ok,  " + Environment.NewLine;
                modList.UndersizeImage = "Not Ok";
            }
            else if (chequeDeposit.UndersizeImage == "2")
            {
                modList.UndersizeImage = "Ok";
            }
            // modList.FoldedorTornDocumentCorners = chequeDeposit.FoldedorTornDocumentCorners;
            if (chequeDeposit.FoldedorTornDocumentCorners == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded or Torn Document Corners is not Ok,  " + Environment.NewLine;
                modList.FoldedorTornDocumentCorners = "Not Ok";
            }
            else if (chequeDeposit.FoldedorTornDocumentCorners == "2")
            {
                modList.FoldedorTornDocumentCorners = "Ok";
            }
            // modList.FoldedOrTornDocumentEdges = chequeDeposit.FoldedOrTornDocumentEdges;
            if (chequeDeposit.FoldedOrTornDocumentEdges == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded Or Torn Document Edges is not Ok,  " + Environment.NewLine;
                modList.FoldedOrTornDocumentEdges = "Not Ok";
            }
            else if (chequeDeposit.FoldedOrTornDocumentEdges == "2")
            {
                modList.FoldedOrTornDocumentEdges = "Ok";
            }
            // modList.FramingError = chequeDeposit.FramingError;
            if (chequeDeposit.FramingError == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Framing Error is not Ok,  " + Environment.NewLine;
                modList.FramingError = "Not Ok";
            }
            else if (chequeDeposit.FramingError == "2")
            {
                modList.FramingError = "Ok";
            }
            //  modList.OversizeImage = chequeDeposit.OversizeImage;
            if (chequeDeposit.OversizeImage == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Over size Image is not Ok,  " + Environment.NewLine;
                modList.OversizeImage = "Not Ok";
            }
            else if (chequeDeposit.OversizeImage == "2")
            {
                modList.OversizeImage = "Ok";
            }
            // modList.ImageTooDark = chequeDeposit.ImageTooDark;
            if (chequeDeposit.ImageTooDark == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Dark is not Ok,  " + Environment.NewLine;
                modList.ImageTooDark = "Not Ok";
            }
            else if (chequeDeposit.ImageTooDark == "2")
            {
                modList.ImageTooDark = "Ok";
            }
            // modList.FrontRearDimensionMismatch = chequeDeposit.FrontRearDimensionMismatch;
            if (chequeDeposit.FrontRearDimensionMismatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Front Rear Dimension Mismatch is not Ok,  " + Environment.NewLine;
                modList.FrontRearDimensionMismatch = "Not Ok";
            }
            else if (chequeDeposit.FrontRearDimensionMismatch == "2")
            {
                modList.FrontRearDimensionMismatch = "Ok";
            }
            //  modList.CarbonStrip = chequeDeposit.CarbonStrip;
            if (chequeDeposit.CarbonStrip == "1")
            {
                counterroe += 1;

                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Carbon Strip is not Ok,  " + Environment.NewLine;
                modList.CarbonStrip = "Not Ok";
            }
            else if (chequeDeposit.CarbonStrip == "2")
            {
                modList.CarbonStrip = "Ok";
            }
            //  modList.OutOfFocus = chequeDeposit.OutOfFocus;
            if (chequeDeposit.OutOfFocus == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Out Of Focus is not Ok,  " + Environment.NewLine;
                modList.OutOfFocus = "Not Ok";
            }
            else if (chequeDeposit.OutOfFocus == "2")
            {
                modList.OutOfFocus = "Ok";
            }
            // modList.QRCodeMatch = chequeDeposit.QRCodeMatch;
            if (chequeDeposit.QRCodeMatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-QR Code Match is not Ok,  " + Environment.NewLine;
                modList.QRCodeMatch = "Not Ok";
            }
            else if (chequeDeposit.QRCodeMatch == "2")
            {
                modList.QRCodeMatch = "Ok";
            }
            // modList.UV = chequeDeposit.UV;
            if (chequeDeposit.UV == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-UV is not Ok,  " + Environment.NewLine;
                modList.UV = "Not Ok";
            }
            else if (chequeDeposit.UV == "2")
            {
                modList.UV = "Ok";
            }
            // modList.MICRPresent = chequeDeposit.MICRPresent;
            if (chequeDeposit.MICRPresent == "1")
            {

                modList.MICRPresent = "No";
            }
            else if (chequeDeposit.MICRPresent == "2")
            {
                modList.MICRPresent = "Yes";
            }
            //  modList.StandardCheque = chequeDeposit.StandardCheque;
            if (chequeDeposit.StandardCheque == "1")
            {
                modList.StandardCheque = "No Standard";
            }
            else if (chequeDeposit.StandardCheque == "2")
            {
                modList.StandardCheque = "Standard";
            }
            // modList.InstrumentDuplicate = chequeDeposit.InstrumentDuplicate;
            if (chequeDeposit.InstrumentDuplicate == "1")
            {
                modList.InstrumentDuplicate = "Duplicate";
            }
            else if (chequeDeposit.InstrumentDuplicate == "2")
            {
                modList.InstrumentDuplicate = "Not Duplicate";
            }
            modList.AverageChequeAmount = chequeDeposit.AverageChequeAmount;
            modList.TotalChequesCount = chequeDeposit.TotalChequesCount;
            modList.TotalChequesReturnCount = chequeDeposit.TotalChequesReturnCount;
            // modList.CaptureAtNIFT_Branch = chequeDeposit.CaptureAtNIFT_Branch;
            if (chequeDeposit.CaptureAtNIFT_Branch == "N")
            {
                modList.CaptureAtNIFT_Branch = "Capture At NIFT";
            }
            else if (chequeDeposit.CaptureAtNIFT_Branch == "B")
            {
                modList.CaptureAtNIFT_Branch = "Capture At Branch";

            }
            if (chequeDeposit.SequenceNumber != null)
            {
                modList.imgF = chequeDeposit.SequenceNumber + "F";
                modList.imgR = chequeDeposit.SequenceNumber + "R";
                modList.imgU = chequeDeposit.SequenceNumber + "U";
            }

            modList.Returnreasone = chequeDeposit.Returnreasone;
            modList.status = chequeDeposit.status;
            modList.Error = chequeDeposit.Error;
            if (modList.Error == true)
            {
                modList.Errors = "Yes";
            }
            else
            {

                modList.Errors = "No";
            }
            if (modList.Export == true)
            {
                modList.Exported = "Yes";
            }
            else
            {
                modList.Exported = "No";
            }
            modList.HubCode = chequeDeposit.HubCode;
            // var model = chequeDeposit.ToModel();
            //UserActivityLog
            _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl,
                $"Image Zoomed for Cheque with AccountNumber={modList.AccountNumber}" +
                $" Date={modList.Date} SerialNumber={modList.serialNo} " +
                $"SenderBankCode={modList.SenderBankCode} " +
                $"ReceiverBankCode={modList.ReceiverBankCode} " +
                $"ChequeNumber={modList.ChequeNumber} SequenceNumber={modList.SequenceNumber} " +
                $"TransactionCode={modList.TransactionCode} Amount={modList.Amount}");
            return View(modList);


        }
        #endregion
        //#region SecurityGroups
        //[HttpPost]
        //[BaseEamAuthorize(PermissionNames = "Monitoring.Import.Read")]
        //public ActionResult SecurityGroupList(long userId, DataSourceRequest command, IEnumerable<Sort> sort = null)
        //{
        //    var securityGroups = _MonitoringRepository.GetById(userId).SecurityGroups;
        //    if (securityGroups.Count == 0)
        //    {
        //        return Json(new DataSourceResult());
        //    }
        //    else
        //    {
        //        var queryable = securityGroups.AsQueryable<SecurityGroup>();
        //        queryable = sort == null ? queryable.OrderBy(a => a.CreatedDateTime) : queryable.Sort(sort);
        //        var data = queryable.ToList().Select(x => x.ToModel()).ToList();
        //        var gridModel = new DataSourceResult
        //        {
        //            Data = data.PagedForCommand(command),
        //            Total = securityGroups.Count()
        //        };

        //        return Json(gridModel);
        //    }
        //}

        public ActionResult CallBackEdit(long id)
        {
            ChequeDepositModel modList = new ChequeDepositModel();
            int counterroe = 0;

            var chequeDeposit = _ChequeDepositRepository.GetById(id);
            modList.Id = chequeDeposit.Id;
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.Date =  chequeDeposit.Date;
            modList.CycleCode = chequeDeposit.CycleCode;
            modList.CityCode = chequeDeposit.CityCode;
            modList.serialNo = chequeDeposit.serialNo;
            modList.SenderBankCode = chequeDeposit.SenderBankCode;
            modList.SenderBranchCode = chequeDeposit.SenderBranchCode;
            modList.ReceiverBankCode = chequeDeposit.ReceiverBankCode;
            modList.ReceiverBranchCode = chequeDeposit.ReceiverBranchCode;
            modList.ChequeNumber = chequeDeposit.ChequeNumber;
            modList.AccountNumber = chequeDeposit.AccountNumber;
            modList.SequenceNumber = chequeDeposit.SequenceNumber;
            modList.TransactionCode = chequeDeposit.TransactionCode;
            modList.Amount = chequeDeposit.Amount;
            modList.chequeDate = chequeDeposit.chequeDate?.ToString("dd/MM/yyyy");
            modList.AcccountTitle = "MUHAMMAD FAROOQ";
            modList.AvailableBalance = 2150000;
            modList.LedgerBalance = "217,108.06";

            // modList.IQATag = chequeDeposit.IQATag;

            if (chequeDeposit.IQATag == "1")
            {

                counterroe += 1;
                modList.IQATag = "Not Ok";
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-IQA Tag is not Ok," + Environment.NewLine;


            }
            else if (chequeDeposit.IQATag == "2")
            {
                modList.IQATag = "Ok";
            }
            // modList.DocumentSkew = chequeDeposit.DocumentSkew;
            if (chequeDeposit.DocumentSkew == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Document Skew is not Ok," + Environment.NewLine;
                modList.DocumentSkew = "Not Ok";


            }
            else if (chequeDeposit.DocumentSkew == "2")
            {

                modList.DocumentSkew = "Ok";
            }
            // modList.Piggyback = chequeDeposit.Piggyback;
            if (chequeDeposit.Piggyback == "1")
            {

                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Piggy back is not Ok,  " + Environment.NewLine;
                modList.Piggyback = "Not Ok";



            }
            else if (chequeDeposit.Piggyback == "2")
            {

                modList.Piggyback = "Ok";
            }
            //  modList.ImageToolight = chequeDeposit.ImageToolight;
            if (chequeDeposit.ImageToolight == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Light is not Ok,  " + Environment.NewLine;
                modList.ImageToolight = "Not Ok";

            }
            else if (chequeDeposit.ImageToolight == "2")
            {
                modList.ImageToolight = "Ok";
            }
            // modList.HorizontalStreaks = chequeDeposit.HorizontalStreaks;
            if (chequeDeposit.HorizontalStreaks == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Horizontal Streaks is not Ok,  " + Environment.NewLine;
                modList.HorizontalStreaks = "Not Ok";
            }
            else if (chequeDeposit.HorizontalStreaks == "2")
            {
                modList.HorizontalStreaks = "Ok";
            }
            // modList.BelowMinimumCompressedImageSize = chequeDeposit.BelowMinimumCompressedImageSize;
            if (chequeDeposit.BelowMinimumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Below Minimum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.BelowMinimumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.BelowMinimumCompressedImageSize == "2")
            {

                modList.BelowMinimumCompressedImageSize = "Ok";
            }
            // modList.AboveMaximumCompressedImageSize = chequeDeposit.AboveMaximumCompressedImageSize;
            if (chequeDeposit.AboveMaximumCompressedImageSize == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Above Maximum Compressed Image Size is not Ok,  " + Environment.NewLine;
                modList.AboveMaximumCompressedImageSize = "Not Ok";
            }
            else if (chequeDeposit.AboveMaximumCompressedImageSize == "2")
            {
                modList.AboveMaximumCompressedImageSize = "Ok";
            }
            // modList.UndersizeImage = chequeDeposit.UndersizeImage;
            if (chequeDeposit.UndersizeImage == "1")
            {
                counterroe = 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Under Size Image is not Ok,  " + Environment.NewLine;
                modList.UndersizeImage = "Not Ok";
            }
            else if (chequeDeposit.UndersizeImage == "2")
            {
                modList.UndersizeImage = "Ok";
            }
            // modList.FoldedorTornDocumentCorners = chequeDeposit.FoldedorTornDocumentCorners;
            if (chequeDeposit.FoldedorTornDocumentCorners == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded or Torn Document Corners is not Ok,  " + Environment.NewLine;
                modList.FoldedorTornDocumentCorners = "Not Ok";
            }
            else if (chequeDeposit.FoldedorTornDocumentCorners == "2")
            {
                modList.FoldedorTornDocumentCorners = "Ok";
            }
            // modList.FoldedOrTornDocumentEdges = chequeDeposit.FoldedOrTornDocumentEdges;
            if (chequeDeposit.FoldedOrTornDocumentEdges == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Folded Or Torn Document Edges is not Ok,  " + Environment.NewLine;
                modList.FoldedOrTornDocumentEdges = "Not Ok";
            }
            else if (chequeDeposit.FoldedOrTornDocumentEdges == "2")
            {
                modList.FoldedOrTornDocumentEdges = "Ok";
            }
            // modList.FramingError = chequeDeposit.FramingError;
            if (chequeDeposit.FramingError == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Framing Error is not Ok,  " + Environment.NewLine;
                modList.FramingError = "Not Ok";
            }
            else if (chequeDeposit.FramingError == "2")
            {
                modList.FramingError = "Ok";
            }
            //  modList.OversizeImage = chequeDeposit.OversizeImage;

            if (chequeDeposit.OversizeImage == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Over size Image is not Ok,  " + Environment.NewLine;
                modList.OversizeImage = "Not Ok";
            }
            else if (chequeDeposit.OversizeImage == "2")
            {
                modList.OversizeImage = "Ok";
            }
            // modList.ImageTooDark = chequeDeposit.ImageTooDark;
            if (chequeDeposit.ImageTooDark == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Image Too Dark is not Ok,  " + Environment.NewLine;
                modList.ImageTooDark = "Not Ok";
            }
            else if (chequeDeposit.ImageTooDark == "2")
            {
                modList.ImageTooDark = "Ok";
            }
            // modList.FrontRearDimensionMismatch = chequeDeposit.FrontRearDimensionMismatch;
            if (chequeDeposit.FrontRearDimensionMismatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Front Rear Dimension Mismatch is not Ok,  " + Environment.NewLine;
                modList.FrontRearDimensionMismatch = "Not Ok";
            }
            else if (chequeDeposit.FrontRearDimensionMismatch == "2")
            {
                modList.FrontRearDimensionMismatch = "Ok";
            }
            //  modList.CarbonStrip = chequeDeposit.CarbonStrip;
            if (chequeDeposit.CarbonStrip == "1")
            {
                counterroe += 1;

                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Carbon Strip is not Ok,  " + Environment.NewLine;
                modList.CarbonStrip = "Not Ok";
            }
            else if (chequeDeposit.CarbonStrip == "2")
            {
                modList.CarbonStrip = "Ok";
            }
            //  modList.OutOfFocus = chequeDeposit.OutOfFocus;
            if (chequeDeposit.OutOfFocus == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-Out Of Focus is not Ok,  " + Environment.NewLine;
                modList.OutOfFocus = "Not Ok";
            }
            else if (chequeDeposit.OutOfFocus == "2")
            {
                modList.OutOfFocus = "Ok";
            }
            // modList.QRCodeMatch = chequeDeposit.QRCodeMatch;
            if (chequeDeposit.QRCodeMatch == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-QR Code Match is not Ok,  " + Environment.NewLine;
                modList.QRCodeMatch = "Not Ok";
            }
            else if (chequeDeposit.QRCodeMatch == "2")
            {
                modList.QRCodeMatch = "Ok";
            }
            // modList.UV = chequeDeposit.UV;
            if (chequeDeposit.UV == "1")
            {
                counterroe += 1;
                modList.ErrorFieldsName = modList.ErrorFieldsName + counterroe + "-UV is not Ok,  " + Environment.NewLine;
                modList.UV = "Not Ok";
            }
            else if (chequeDeposit.UV == "2")
            {
                modList.UV = "Ok";
            }
            // modList.MICRPresent = chequeDeposit.MICRPresent;
            if (chequeDeposit.MICRPresent == "1")
            {

                modList.MICRPresent = "No";
            }
            else if (chequeDeposit.MICRPresent == "2")
            {
                modList.MICRPresent = "Yes";
            }
            //  modList.StandardCheque = chequeDeposit.StandardCheque;
            if (chequeDeposit.StandardCheque == "1")
            {
                modList.StandardCheque = "No Standard";
            }
            else if (chequeDeposit.StandardCheque == "2")
            {
                modList.StandardCheque = "Standard";
            }
            // modList.InstrumentDuplicate = chequeDeposit.InstrumentDuplicate;
            if (chequeDeposit.InstrumentDuplicate == "1")
            {
                modList.InstrumentDuplicate = "Duplicate";
            }
            else if (chequeDeposit.InstrumentDuplicate == "2")
            {
                modList.InstrumentDuplicate = "Not Duplicate";
            }
            modList.AverageChequeAmount = chequeDeposit.AverageChequeAmount;
            modList.TotalChequesCount = chequeDeposit.TotalChequesCount;
            modList.TotalChequesReturnCount = chequeDeposit.TotalChequesReturnCount;
            // modList.CaptureAtNIFT_Branch = chequeDeposit.CaptureAtNIFT_Branch;
            if (chequeDeposit.CaptureAtNIFT_Branch == "N")
            {
                modList.CaptureAtNIFT_Branch = "Capture At NIFT";
            }
            else if (chequeDeposit.CaptureAtNIFT_Branch == "B")
            {
                modList.CaptureAtNIFT_Branch = "Capture At Branch";

            }
            if (chequeDeposit.SequenceNumber != null)
            {
                modList.imgF = chequeDeposit.SequenceNumber + "F";
                modList.imgR = chequeDeposit.SequenceNumber + "R";
                modList.imgU = chequeDeposit.SequenceNumber + "U";
            }

            modList.Returnreasone = chequeDeposit.Returnreasone;
            modList.status = chequeDeposit.status;
            modList.Error = chequeDeposit.Error;
            if (modList.Error == true)
            {
                modList.Errors = "Yes";
            }
            else
            {

                modList.Errors = "No";
            }
            if (modList.Export == true)
            {
                modList.Exported = "Yes";
            }
            else
            {
                modList.Exported = "No";
            }
            modList.HubCode = chequeDeposit.HubCode;
            // var model = chequeDeposit.ToModel();


            var status = new List<SelectListItem>();


            status.Add(new SelectListItem()
            {
                Text = "(101) Ammount in word and figure differs",
                Value = " (101) Ammount in word and figure differs",

            });
            status.Add(new SelectListItem()
            {
                Text = "(102) Insufficient funds in drawer’s account",
                Value = "(102) Insufficient funds in drawer’s account",

            });

            status.Add(new SelectListItem()
            {
                Text = "(201) Date is Missing / Invalid",
                Value = "(201) Date is Missing / Invalid",

            });
            status.Add(new SelectListItem()
            {
                Text = "(202) Duplicate instrument / Instrument lodged again in Clearing",
                Value = "(202) Duplicate instrument / Instrument lodged again in Clearing",

            });
            status.Add(new SelectListItem()
            {
                Text = "(301) Closed / Inactive Account",
                Value = "(301) Closed / Inactive Account",

            });
            status.Add(new SelectListItem()
            {
                Text = "(401) Bank’s special crossing required",
                Value = "(401) Bank’s special crossing required",

            });
            status.Add(new SelectListItem()
            {
                Text = "(501) Payment stopped by drawer",
                Value = "(501) Payment stopped by drawer",

            });
            status.Add(new SelectListItem()
            {
                Text = "(601) Alteration on payment instrument requires drawer's signature",
                Value = "(601)  Alteration on payment instrument requires drawer's signature",

            });
            status.Add(new SelectListItem()
            {
                Text = "(604) Signature is unauthorized / differ from specimen on record",
                Value = "(604) Signature is unauthorized / differ from specimen on record",

            });
            status.Add(new SelectListItem()
            {
                Text = "(900) Payment defer for physical instrument review",
                Value = "(900) Payment defer for physical instrument review",

            });
            long userid = this._workContext.CurrentUser.Id;
            TempData[NohaFMS.Web.Framework.Session.SessionKey.TEMP_User_Id] = userid;
            Session[SessionKey.SESSION_ReturnReason_LIST] = status;
            return View(modList);
        }
        [HttpPost]
        public ActionResult CallBackEdit(ChequeDepositModel model)
        {
            long userid = this._workContext.CurrentUser.Id;

     

            string dt = model.chequeDate;
            DateTime DT = DateTime.ParseExact(dt, "dd/MM/yyyy", CultureInfo.InvariantCulture);

            DateTime Ago = DateTime.Today.AddDays(-180);

            if (DT < Ago)
            {
                //notification
                ErrorNotification("Cheque Date should be within  180 days");
                return new NullJsonResult();
            }
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();
            ChequeDepositModel mod = new ChequeDepositModel();
            var resultt = _ChequeDepositRepository.GetById(model.Id);

            if (model.status == "V")
            {
                var Limit = _chequedepositService.GetLimit(userid);
                if (resultt.Amount > Limit)
                {
                    ErrorNotification("Your limit mismatch");
                    return new NullJsonResult();
                }
            }





            resultt.Returnreasone = model.Returnreasone;
            //  resultt.Callback = true;
            resultt.chequeDate = DT;

            // resultt = model.ToEntity(resultt);

            //always set IsNew to false when saving
            
                resultt.Callback = true;
            resultt.IsNew = false;
            if (model.Amount > 100000 && userid != 1)
            {
                ErrorNotification("Forward to Approval");
                resultt.Callback = true;
            }
            else
            {
                resultt.status = model.status;
                //UserActivityLog
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $"CallBack " +
                    $"Record Saved Successfully with Id-Amount-Status are:{model.Id}-{model.Amount}-{resultt.status}");
                SuccessNotification("Record Saved Seccessfully");
            }
            //update attributes
            _entityAttributeService.UpdateEntityAttributes(model.Id, EntityType.ChequeDepositInformation, json);
            _ChequeDepositRepository.Update(resultt);

            //commit all changes
            this._dbContext.SaveChanges();

            //notification

            return new NullJsonResult();


        }



        public ActionResult Email(long id)
        {
            try
            {
                var senderEmail = new MailAddress("m.farooqfayyaz93@gmail.com", "Muhammad Farooq");
                var receiverEmail = new MailAddress("ali.zs0002@gmail.com", "Receiver");
                var password = "farooq_bs20";
                // var sub = "Call Back Test";
                var body = "Call back";
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 25,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,

                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = "Call back",
                    Body = body
                })
                {
                    //  smtp.UseDefaultCredentials = false;
                    smtp.Send(mess);
                }
                TempData[SessionKey.TEMP_DATA_RESPONSE_MESSAGE] = "Email Successfully send";
                //UserActivityLog
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl,$"Email Sended to {receiverEmail} Successfully from {senderEmail}");

                return RedirectToAction("CallBack", "ChequeDeposit");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public ActionResult SendEmailSelected(ICollection<long> selectedIds)
        {
            Stream req = Request.InputStream;
            req.Seek(0, SeekOrigin.Begin);
            string json = new StreamReader(req).ReadToEnd();

            try
            {
                //var items = new List<ChequeDepositInformation>();
                foreach (long id in selectedIds)
                {
                    var resultt = _ChequeDepositRepository.GetById(id);

                    ////UserActivityLog
                    //_chequedepositService.MonitoringActivityFlowlog(_workContext.CurrentUser.Id, "USER [" + _workContext.CurrentUser.Name + "] CallBack ID:[" + resultt.Id + "] Amount:[" + resultt.Amount + "]");


                    if (resultt != null && resultt.status == "C")
                    {
                        resultt.Callbacksend = true;

                        _entityAttributeService.UpdateEntityAttributes(id, EntityType.ChequeDepositInformation, json);

                        _ChequeDepositRepository.Update(resultt);

                        //commit all changes
                        this._dbContext.SaveChanges();
                        SuccessNotification("Send Successfully");
                        //try
                        //{
                        //    var senderEmail = new MailAddress("m.farooqfayyaz93@gmail.com", "Muhammad Farooq");
                        //    var receiverEmail = new MailAddress("m.farooqfayyaz93@gmail.com", "Receiver");
                        //    var password = "farooq_bs20";
                        //    // var sub = "Call Back Test";
                        //    var body = "Call back";
                        //    var smtp = new SmtpClient
                        //    {
                        //        Host = "smtp.gmail.com",
                        //        Port = 25,
                        //        EnableSsl = true,
                        //        DeliveryMethod = SmtpDeliveryMethod.Network,
                        //        UseDefaultCredentials = false,

                        //        Credentials = new NetworkCredential(senderEmail.Address, password)
                        //    };
                        //    using (var mess = new MailMessage(senderEmail, receiverEmail)
                        //    {
                        //        Subject = "Call back",
                        //        Body = body
                        //    })
                        //    {
                        //        //  smtp.UseDefaultCredentials = false;
                        //        smtp.Send(mess);
                        //    }
                        //    TempData[SessionKey.TEMP_DATA_RESPONSE_MESSAGE] = "Call Backs done Successfully";


                        //    return RedirectToAction("CallBack", "ChequeDeposit");
                        //}
                        //catch (Exception ex)
                        //{
                        //    throw ex;
                        //}
                    }
                }




                return new NullJsonResult();

            }
            catch (Exception ex)
            {
                throw ex;

                // return Json(new { Errors = ModelState.SerializeErrors() });

            }

        }
    }
}
