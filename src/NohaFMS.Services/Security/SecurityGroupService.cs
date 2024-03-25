/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Core.Kendoui;
using NohaFMS.Data;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Data.SqlClient;
using System.Web;

namespace NohaFMS.Services
{
    public class SecurityGroupService : BaseService, ISecurityGroupService
    {
        #region Fields

        private readonly IRepository<SecurityGroup> _securityGroupRepository;
        private readonly DapperContext _dapperContext;
        private readonly IWorkContext _workContext;
        private readonly IUserActivityService _userActivityService;
        private readonly HttpContextBase _httpContext;
        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public SecurityGroupService(IRepository<SecurityGroup> securityGroupRepository,
            DapperContext dapperContext, IWorkContext workContext,IUserActivityService userActivityService, HttpContextBase httpContext)
        {
            this._securityGroupRepository = securityGroupRepository;
            this._dapperContext = dapperContext;
            this._workContext = workContext;
            this._userActivityService = userActivityService;
            this._httpContext = httpContext;
        }

        #endregion

        #region Methods

        public virtual PagedResult<SecurityGroup> GetSecurityGroups(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.SecurityGroupSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("Name");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.SecurityGroupSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var securityGroups = connection.Query<SecurityGroup>(search.RawSql, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<SecurityGroup>(securityGroups, totalCount);
            }
        }

        public void SecurityActivityFlowlog(long id, string description)
        {
            DateTime dto = System.DateTime.Now;
            //string constr = ConfigurationManager.ConnectionStrings();


            var user = _workContext.CurrentUser.Id;
            string connection = _dapperContext.ConnectionString;


            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                // string desc = "City Created where Id is:" + id.ToString();
                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + description.ToString() + "','" + user+ "','" + dto.ToString() + "')";





                //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

                //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


                SqlCommand command = new SqlCommand(query, connect);



                connect.Open();

                //string des = (string)onlyonedesc.ExecuteScalar();
                //h = des;
                //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
                //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

                //SqlCommand command1 = new SqlCommand(query1, connect);

                //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
                //string CustomerName = (string)CmdName.ExecuteScalar();

                command.ExecuteNonQuery();

                connect.Close();

            }

        }

        public void SearchFilterLog(string id,string fGroup)
        {
            
           
            string groupname;
            

            if (fGroup== null||fGroup=="")
            {
                groupname = $"{fGroup}";
            }
            else
            {
                groupname = $"Group Id = {id} and Name = {fGroup}";
            }

            string data = $"{groupname}";
            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string desc = $"Searched for {data}";
                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, desc);


            }
        }

        static string ctname, ctcode;


        public void Klog(long id, string description)
        {
            ctname = null;
            ctcode = null;
            
        }
        public void groupBeforeEditBtnLog(long id)
        {
            var group = _securityGroupRepository.GetById(id);
            ctcode = group.Name;
            ctname = group.Description;
         
        }

        public void groupAfterEditBtnLog(long id, bool IsCreate)
        {
            var beforeBranchName = ctname;
            var beforeBranchCode = ctcode;
            

            var afterChange = _securityGroupRepository.GetById(id);
            
            string cName, cCode;

            if (afterChange.Name != beforeBranchName)
            {
                cName = $" Name= {beforeBranchName}->{afterChange.Name},";
            }
            else { cName = ""; }
            if (afterChange.Description != beforeBranchCode)
            {
                cCode = $" Description= {beforeBranchCode}->{afterChange.Description},";
            }
            else { cCode = ""; }


          

            string data = $"{cName}{cCode}";

            if (data == "")
            {
                data = "Searched for Nothing";
            }
            else
            {
                string operation;
                if (IsCreate == true)
                {

                    operation = $"Group has been created with Id={id}";

                }
                else
                {
                    string combindedString = string.Join(",", afterChange.Users);

                    operation = $"Group Modified of Id={id}, Name and Description are: " + afterChange.Name + "-" + afterChange.Description+" with Users:"+combindedString;
                }


                _userActivityService.InsertActivityLog("UrlAccessed", _httpContext.Request.RawUrl, $" {operation}   {data}");


            }




        }


        #endregion
    }
}
