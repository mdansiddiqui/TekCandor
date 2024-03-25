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
using NohaFMS.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Newtonsoft.Json;
using NohaFMS.Web.Framework;
using System.IO;
using System.Data;
using System.Web;
using CrystalDecisions.CrystalReports.Engine;

namespace NohaFMS.Web.Controllers
{
    public class ReportViewerController : BaseController
    {
        #region Fields

        private readonly IRepository<Report> _reportRepository;
        private readonly IRepository<ReportFilter> _reportFilterRepository;
        private readonly IRepository<ReportColumn> _reportColumnRepository;
        private readonly IReportService _reportService;
        private readonly IDateTimeHelper _dateTimeHelper;
        private readonly ILocalizationService _localizationService;
        private readonly IPermissionService _permissionService;
        private readonly HttpContextBase _httpContext;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;
        private readonly IRepository<Site> _siteRepository;

        #endregion

        #region Constructors

        public ReportViewerController(IRepository<Report> reportRepository,
            IRepository<ReportFilter> reportFilterRepository,
            IRepository<ReportColumn> reportColumnRepository,
            IRepository<Site> siteRepository,
            IReportService reportService,
            IDateTimeHelper dateTimeHelper,
            ILocalizationService localizationService,
            IPermissionService permissionService,
            HttpContextBase httpContext,
            IWorkContext workContext,
            IDbContext dbContext)
        {
            this._reportRepository = reportRepository;
            this._reportFilterRepository = reportFilterRepository;
            this._reportColumnRepository = reportColumnRepository;
            this._localizationService = localizationService;
            this._reportService = reportService;
            this._dateTimeHelper = dateTimeHelper;
            this._permissionService = permissionService;
            this._siteRepository = siteRepository;
            this._httpContext = httpContext;
            this._workContext = workContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Utilities

        private SearchModel BuildSearchModel(List<ReportFilter> reportFilters)
        {
            var model = new SearchModel();
            if(reportFilters.Count > 0)
            {
                reportFilters = reportFilters.OrderBy(r => r.DisplayOrder).ToList();
                foreach(var reportFilter in reportFilters)
                {
                    var field = new FieldModel
                    {
                        DisplayOrder = reportFilter.DisplayOrder,
                        Name = reportFilter.Name,
                        ResourceKey = reportFilter.ResourceKey,
                        DbColumn = reportFilter.DbColumn,
                        Value = null,
                        ControlType = (FieldControlType)reportFilter.Filter.ControlType,
                        DataType = (FieldDataType)reportFilter.Filter.DataType,
                        DataSource = (FieldDataSource)reportFilter.Filter.DataSource,
                        IsRequiredField = reportFilter.IsRequired,
                        CsvTextList = reportFilter.Filter.CsvTextList,
                        CsvValueList = reportFilter.Filter.CsvValueList,
                        DbTable = reportFilter.Filter.DbTable,
                        DbTextColumn = reportFilter.Filter.DbTextColumn,
                        DbValueColumn = reportFilter.Filter.DbValueColumn,
                        SqlQuery = reportFilter.Filter.SqlQuery,
                        SqlTextField = reportFilter.Filter.SqlTextField,
                        SqlValueField = reportFilter.Filter.SqlValueField,
                        SessionKey = reportFilter.Report.Name,
                        MvcController = reportFilter.Filter.MvcController,
                        MvcAction = reportFilter.Filter.MvcAction,
                        AdditionalField = reportFilter.Filter.AdditionalField,
                        AdditionalValue = reportFilter.Filter.AdditionalValue,
                        AutoBind = reportFilter.Filter.AutoBind,
                        ParentFieldName = reportFilter.ParentReportFilter == null ? "" : reportFilter.ParentReportFilter.Name,
                        LookupType = reportFilter.Filter.LookupType,
                        LookupTextField = reportFilter.Filter.LookupTextField,
                        LookupValueField = reportFilter.Filter.LookupValueField
                    };
                    model.Filters.Add(field);
                }
            }
            return model;
        }

        #endregion

        #region Methods

        public ActionResult View(long id)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(id);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return AccessDeniedView();

            var model = _httpContext.Session[report.Name] as SearchModel;
            //If not exist, build search model
            if (model == null)
            {
                model = BuildSearchModel(report.ReportFilters.ToList());
                //session save
                _httpContext.Session[report.Name] = model;
            }

            ViewBag.ReportName = report.Name;
            ViewBag.ReportId = report.Id;
            return View(model);
        }

        public ActionResult ViewReport(long reportId, DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(reportId);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return AccessDeniedView();

            var model = _httpContext.Session[report.Name] as SearchModel;
            if (model == null)
                model = BuildSearchModel(report.ReportFilters.ToList());
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
                _httpContext.Session[report.Name] = model;

                IEnumerable<dynamic> result = _reportService.GetReportData(
                    report,
                    report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                    model.ToParameters(),
                    command.Page - 1,
                    command.PageSize, sort);
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Path.Combine(Server.MapPath("~/Reports/"), "ChequeDepositList.rpt"));
                    rd.SetDataSource(result);
                    Response.Buffer = false;
                    Response.ClearContent();

                var gridModel = new DataSourceResult
                {
                    Data = result.PagedForCommand(command),
                    Total = result.Count()
                };
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "abc.pdf");

                //Must use json.net to serialize dynamic object return by Dapper => so it can have the format {"name": "value"} that match column field format of Kendo UI grid
                //string json = JsonConvert.SerializeObject(gridModel);
                //return Content(json, "application/json");
            }

            return Json(new { Errors = ModelState.SerializeErrors() });
        }
        [HttpPost]
        public ActionResult ColumnMappings(long reportId)
        {
            if (reportId == 0)
            {
                return new NullJsonResult();
            }
            var columnMappings = _reportColumnRepository.GetAll()
                .Where(r => r.ReportId == reportId).OrderBy(r => r.DisplayOrder).ToList();

            var result = (from s in columnMappings
                          select new
                          {
                              columnName = s.ColumnName,
                              dataType = s.DataType,
                              headerText = _localizationService.GetResource(s.ResourceKey),
                              format = s.FormatString
                          }).ToList();

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult List(long reportId, DataSourceRequest command, string searchValues, IEnumerable<Sort> sort = null)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(reportId);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return AccessDeniedView();

            var model = _httpContext.Session[report.Name] as SearchModel;
            if (model == null)
                model = BuildSearchModel(report.ReportFilters.ToList());
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
                _httpContext.Session[report.Name] = model;

                IEnumerable<dynamic> result = _reportService.GetReportData(
                    report, 
                    report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(), 
                    model.ToParameters(), 
                    command.Page - 1, 
                    command.PageSize, sort);

                var gridModel = new DataSourceResult
                {
                    Data = result.PagedForCommand(command),
                    Total = result.Count()
                };

                //Must use json.net to serialize dynamic object return by Dapper => so it can have the format {"name": "value"} that match column field format of Kendo UI grid
                string json = JsonConvert.SerializeObject(gridModel);
                return Content(json, "application/json");
            }

            return Json(new { Errors = ModelState.SerializeErrors() });
        }

        public FileResult ExportToCsv(string searchValues, long reportId)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(reportId);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return File(new byte[1], "", "");

            var model = _httpContext.Session[report.Name] as SearchModel;
            if (model == null)
                model = BuildSearchModel(report.ReportFilters.ToList());
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
                _httpContext.Session[report.Name] = model;

                var searchDict = ParseSearchValues(searchValues);
                if (report.TemplateType == (int?)(ReportTemplateType.Grid))
                {
                    IEnumerable<dynamic> reportData =
                    _reportService.GetReportData(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);

                    MemoryStream output = _reportService.ExportToCsv(reportId, reportData);
                    //Return the result to the end user
                    return File(output.ToArray(),   //The binary data of the csv file
                        "text/comma-separated-values", //MIME type of csv files
                        report.Name.Replace(" ", "_") + ".csv");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }
                else if (report.TemplateType == (int?)(ReportTemplateType.CrystalReport))
                {
                    // Report loading through multiple datasets handling
                    List<IEnumerable<dynamic>> reportDataMultiple =
                    _reportService.GetReportDataMultiple(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);

                    Site client = new Site();
                    string reportSecondTitle = string.Empty;
                    foreach (ReportFilter rFilter in report.ReportFilters)
                    {
                        if (rFilter.Filter.Name.ToLower() == "site")
                        {
                            FieldModel siteModel = model.Filters.Find(f => f.MvcController != null && f.MvcController.ToLower() == "site");
                            if (siteModel != null && siteModel.Value != null)
                            {
                                var siteSearchModel = BuildSiteSearchModelForSiteId((long)siteModel.Value);
                                client = _siteRepository.GetById(siteModel.Value);
                                //PagedResult<Site> data = _siteService.GetSitesWithAddress(siteSearchModel.ToExpression(), siteSearchModel.ToParameters());
                                //if (data.Result.Count() > 0)
                                //    client = data.Result.FirstOrDefault();
                            }
                        }
                        else if (rFilter.IsRequired && rFilter.Filter.Name.ToLower() == "worktype")
                        {

                            if (searchDict.ContainsKey(rFilter.Name + "_input") && !string.IsNullOrEmpty(searchDict[rFilter.Name + "_input"]))
                            {
                                reportSecondTitle = searchDict[rFilter.Name + "_input"].ToString();
                            }
                            //FieldModel siteModel = model.Filters.Find(f => f.MvcController.ToLower() == "site");
                        }
                    }
                    Stream output = _reportService.CrystalReportExport(report, searchDict, reportDataMultiple, 8, reportSecondTitle, this._workContext.CurrentUser, client);
                    //Return the result to the end user
                    return File(output,   //The binary data of the csv file
                        "text/comma-separated-values", //MIME type of csv files
                        report.Name.Replace(" ", "_") + ".csv");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }                    
            }

            return File(new byte[1], "", "");
        }

        public FileResult ExportToExcel(string searchValues, long reportId)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(reportId);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return File(new byte[1], "", "");

            var model = _httpContext.Session[report.Name] as SearchModel;
            if (model == null)
                model = BuildSearchModel(report.ReportFilters.ToList());
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
                _httpContext.Session[report.Name] = model;

                var searchDict = ParseSearchValues(searchValues);
                if (report.TemplateType == (int?)(ReportTemplateType.Grid))
                {
                    IEnumerable<dynamic> reportData =
                    _reportService.GetReportData(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);
                    ReportDocument rd = new ReportDocument();
                    rd.Load(Path.Combine(Server.MapPath("~/Report"), "ChequeDepositList.rpt"));
                    rd.SetDataSource(reportData);
                    Response.Buffer = false;
                    Response.ClearContent();
                    MemoryStream output = _reportService.ExportToExcel(reportId, reportData);
                    //Return the result to the end user
                    return File(output.ToArray(),   //The binary data of the XLS file
                        "application/vnd.ms-excel", //MIME type of Excel files
                        report.Name.Replace(" ", "_") + ".xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }
                else if (report.TemplateType == (int?)(ReportTemplateType.CrystalReport))
                {
                    // Report loading through multiple datasets handling
                    List<IEnumerable<dynamic>> reportDataMultiple =
                    _reportService.GetReportDataMultiple(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);

                    Site client = new Site();
                    string reportSecondTitle = string.Empty;
                    foreach (ReportFilter rFilter in report.ReportFilters)
                    {
                        if (rFilter.Filter.Name.ToLower() == "site")
                        {
                            FieldModel siteModel = model.Filters.Find(f => f.MvcController != null && f.MvcController.ToLower() == "site");
                            if (siteModel != null && siteModel.Value != null)
                            {
                                var siteSearchModel = BuildSiteSearchModelForSiteId((long)siteModel.Value);
                                client = _siteRepository.GetById(siteModel.Value);
                                //PagedResult<Site> data = _siteService.GetSitesWithAddress(siteSearchModel.ToExpression(), siteSearchModel.ToParameters());
                                //if (data.Result.Count() > 0)
                                //    client = data.Result.FirstOrDefault();
                            }
                        }
                        else if (rFilter.IsRequired && rFilter.Filter.Name.ToLower() == "worktype")
                        {

                            if (searchDict.ContainsKey(rFilter.Name + "_input") && !string.IsNullOrEmpty(searchDict[rFilter.Name + "_input"]))
                            {
                                reportSecondTitle = searchDict[rFilter.Name + "_input"].ToString();
                            }
                            //FieldModel siteModel = model.Filters.Find(f => f.MvcController.ToLower() == "site");
                        }
                    }

                    Stream output = _reportService.CrystalReportExport(report, searchDict, reportDataMultiple, 4, reportSecondTitle, this._workContext.CurrentUser, client);
                    //Return the result to the end user
                    return File(output,   //The binary data of the XLS file
                        "application/vnd.ms-excel", //MIME type of Excel files
                        report.Name.Replace(" ", "_") + ".xls");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }                
            }

            return File(new byte[1], "", "");
        }

        private SearchModel BuildSiteSearchModelForSiteId(long siteId)
        {
            var model = new SearchModel();
            var siteIdFilter = new FieldModel
            {
                DisplayOrder = 1,
                Name = "Id",
                ResourceKey = "Site.Id",
                DbColumn = "Site.Id",
                Operator = FieldOperatorType.eq,
                Value = siteId,
                ControlType = FieldControlType.TextBox,
                DataType = FieldDataType.Int64,
                DataSource = FieldDataSource.None,
                IsRequiredField = true
            };
            model.Filters.Add(siteIdFilter);

            return model;
        }

        private Dictionary<string, string> ParseSearchValues(string searchValues)
        {
            var searchValuesDictionary = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(searchValues))
                return searchValuesDictionary;
            var filters = searchValues.Split('&');
            if (filters.Count() > 0)
            {
                foreach (var filter in filters)
                {
                    var filterKeyValue = filter.Split('=');
                    if (filterKeyValue.Count() != 2)
                    {
                        throw new NohaFMSException("Not valid form.");
                    }
                    else
                    {
                        //This check is for multiselect values
                        if (searchValuesDictionary.ContainsKey(filterKeyValue[0]))
                        {
                            //build a value has format '1','2','3' so it can be replaced in an IN clause
                            searchValuesDictionary[filterKeyValue[0]] = "'" + searchValuesDictionary[filterKeyValue[0]] + "','" + filterKeyValue[1] + "'";
                            searchValuesDictionary[filterKeyValue[0]] = searchValuesDictionary[filterKeyValue[0]].Replace("''", "'");
                        }
                        else
                        {
                            searchValuesDictionary.Add(filterKeyValue[0], HttpUtility.UrlDecode(filterKeyValue[1]));
                        }
                    }
                }
            }

            return searchValuesDictionary;
        }

        public FileResult ExportToPdf(string searchValues, long reportId)
        {
            //check permission
            var securityGroupIds = _workContext.CurrentUser.SecurityGroups.Select(s => s.Id).ToList();
            var report = _reportRepository.GetById(reportId);
            if (!report.SecurityGroups.Any(s => securityGroupIds.Contains(s.Id)))
                return File(new byte[1], "", "");

            var model = _httpContext.Session[report.Name] as SearchModel;
            if (model == null)
                model = BuildSearchModel(report.ReportFilters.ToList());
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
                _httpContext.Session[report.Name] = model;

                var searchDict = ParseSearchValues(searchValues);
                
                if (report.TemplateType == (int?)(ReportTemplateType.Grid))
                {
                    IEnumerable<dynamic> reportData = null;
                    _reportService.GetReportData(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);
                    MemoryStream output = _reportService.ExportToPdf(reportId, reportData);

                    //Return the result to the end user
                    return File(output.ToArray(),   //The binary data of the pdf file
                        "application/pdf", //MIME type of pdf files
                        report.Name.Replace(" ", "_") + ".pdf");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }
                else if (report.TemplateType == (int?)(ReportTemplateType.CrystalReport))
                {
                    // Report loading through multiple datasets handling
                    List<IEnumerable<dynamic>> reportDataMultiple =
                    _reportService.GetReportDataMultiple(
                        report,
                        report.IncludeCurrentUserInQuery == true ? model.ToExpression(this._workContext.CurrentUser.Id) : model.ToExpression(),
                        model.ToParameters(),
                        0,
                        2147483647,
                        null);

                    Site client = new Site();
                    string reportSecondTitle = string.Empty;
                    foreach (ReportFilter rFilter in report.ReportFilters)
                    {
                        if (rFilter.Filter.Name.ToLower() == "site")
                        {
                            FieldModel siteModel = model.Filters.Find(f => f.MvcController != null && f.MvcController.ToLower() == "site");
                            if (siteModel != null && siteModel.Value != null)
                            {   
                                var siteSearchModel = BuildSiteSearchModelForSiteId((long)siteModel.Value);
                                client = _siteRepository.GetById(siteModel.Value);
                                //PagedResult<Site> data = _siteService.GetSitesWithAddress(siteSearchModel.ToExpression(), siteSearchModel.ToParameters());
                                //if (data.Result.Count() > 0)
                                //    client = data.Result.FirstOrDefault();
                            }
                        }
                        else if (rFilter.IsRequired && rFilter.Filter.Name.ToLower() == "worktype")
                        {
                            
                            if (searchDict.ContainsKey(rFilter.Name + "_input") && !string.IsNullOrEmpty(searchDict[rFilter.Name + "_input"]))
                            {
                                reportSecondTitle = searchDict[rFilter.Name + "_input"].ToString();
                            }
                            //FieldModel siteModel = model.Filters.Find(f => f.MvcController.ToLower() == "site");
                        }   
                    }
                    Stream output = _reportService.CrystalReportExport(report, searchDict, reportDataMultiple, 5,reportSecondTitle, this._workContext.CurrentUser, client);

                    //Return the result to the end user
                    return File(output,   //The binary data of the pdf file
                        "application/pdf", //MIME type of pdf files
                        report.Name.Replace(" ", "_") + ".pdf");     //Suggested file name in the "Save as" dialog which will be displayed to the end user
                }
            }

            return File(new byte[1], "", "");
        }

        #endregion
    }
}