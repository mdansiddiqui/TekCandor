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

namespace NohaFMS.Services
{
    public class ServiceRequestService : BaseService, IServiceRequestService
    {
        #region Fields

        private readonly IRepository<ServiceRequest> _serviceRequestRepository;
        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Assignment> _assignmentRepository;
        private readonly DapperContext _dapperContext;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;

        #endregion

        #region Ctor

        /// <summary>
        /// Ctor
        /// </summary>
        public ServiceRequestService(IRepository<ServiceRequest> serviceRequestRepository,
            IRepository<User> userRepository,
            IRepository<Assignment> assignmentRepository,
            DapperContext dapperContext,
            IWorkContext workContext,
            IDbContext dbContext)
        {
            this._serviceRequestRepository = serviceRequestRepository;
            this._userRepository = userRepository;
            this._assignmentRepository = assignmentRepository;
            this._dapperContext = dapperContext;
            this._workContext = workContext;
            this._dbContext = dbContext;
        }

        #endregion

        #region Methods
        public virtual PagedResult<ServiceRequest> GetServiceRequests(string expression,
            dynamic parameters,
            int pageIndex = 0,
            int pageSize = 2147483647,
            IEnumerable<Sort> sort = null)
        {
            var searchBuilder = new SqlBuilder();
            var search = searchBuilder.AddTemplate(SqlTemplate.ServiceRequestSearch(), new { skip = pageIndex * pageSize, take = pageSize });
            if (!string.IsNullOrEmpty(expression))
                searchBuilder.Where(expression, parameters);
            if (sort != null)
            {
                foreach (var s in sort)
                    searchBuilder.OrderBy(s.ToExpression());
            }
            else
            {
                searchBuilder.OrderBy("ServiceRequest.Number");
            }

            var countBuilder = new SqlBuilder();
            var count = countBuilder.AddTemplate(SqlTemplate.ServiceRequestSearchCount());
            if (!string.IsNullOrEmpty(expression))
                countBuilder.Where(expression, parameters);

            using (var connection = _dapperContext.GetOpenConnection())
            {
                var serviceRequests = connection.Query<ServiceRequest, Asset, Location, Site, Assignment, ServiceRequest >(search.RawSql,
                    (serviceRequest, asset, location, site, assignment) => { serviceRequest.Asset = asset; serviceRequest.Location = location; serviceRequest.Site = site; serviceRequest.Assignment = assignment; return serviceRequest; }, search.Parameters);
                var totalCount = connection.Query<int>(count.RawSql, search.Parameters).Single();
                return new PagedResult<ServiceRequest>(serviceRequests, totalCount);
            }
        }

        public virtual List<User> GetCreatedUser(long id)
        {
            var result = new List<User>();
            var serviceRequest = _serviceRequestRepository.GetById(id);
            var createdUser = _userRepository.GetById(serviceRequest.CreatedUserId);
            result.Add(createdUser);
            return result;
        }

        public void AutoCloseServiceRequest(long? serviceRequestId)
        {
            if (serviceRequestId == null)
                return;

            ServiceRequest serviceRequestToClose = _serviceRequestRepository.GetById(serviceRequestId);
            var assignment = _assignmentRepository.GetById(serviceRequestToClose.Id);
            WorkflowServiceClient.TriggerWorkflowAction(serviceRequestToClose.Id, EntityType.ServiceRequest, assignment.WorkflowDefinitionId, assignment.WorkflowInstanceId,
                       assignment.WorkflowVersion.Value, WorkflowActionName.Close, "ServiceRequest", this._workContext.CurrentUser.Id);

        }

        public virtual List<User> GetRequestor(long id)
        {
            var result = new List<User>();
            var serviceRequest = _serviceRequestRepository.GetById(id);
            var requestor = new User
            {
                Email = serviceRequest.RequestorEmail,
                Phone = serviceRequest.RequestorPhone
            };
            result.Add(requestor);
            return result;
        }



        public void MaintenanceActivityFlowlog(long id, string description)
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
                   "Values('" + description.ToString() + "','" + user + "','" + dto.ToString() + "')";





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




        #endregion
    }
}
