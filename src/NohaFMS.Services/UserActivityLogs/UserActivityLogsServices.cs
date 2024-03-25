using System;
using System.Data.SqlClient;
using System.Web;
using NohaFMS.Core;
using NohaFMS.Core.Data;
using NohaFMS.Core.Domain;
using NohaFMS.Data;

namespace NohaFMS.Services
{
    public class UserActivityLogsServices
    {
        #region Fields


    //    private readonly IRepository<NohaFMS.Core.Domain.IUserActivityLogs> _userActivityLogRepository;
        private readonly IRepository<ActivityLogType> _activityLogTypeRepository;
        private readonly DapperContext _dapperContext;
        private readonly IRepository<User> _userRepository;
        private readonly IWorkContext _workContext;
        private readonly IDbContext _dbContext;
        private readonly HttpContextBase _httpContext;

        public UserActivityLogsServices()
        {
        }
        #endregion

        #region Constructors

        public UserActivityLogsServices(

      //      IRepository<NohaFMS.Core.Domain.IUserActivityLogs> userActivityLogRepository,
            IRepository<ActivityLogType> activityLogTypeRepository,
            DapperContext dapperContext,
            IRepository<User> userRepository,
            IWorkContext workContext,
            IDbContext dbContext,
            HttpContextBase httpContext)
        {

        //    this._userActivityLogRepository = userActivityLogRepository;
            this._dapperContext = dapperContext;
            this._userRepository = userRepository;
            this._workContext = workContext;
            this._dbContext = dbContext;
            this._httpContext = httpContext;

        }


        #endregion

        #region Method
        public virtual void InsertUserActivityLogs(long uid, string description)
        {
          //  string url_Access=_httpContext.Request.RawUrl;
            //var user = _workContext.CurrentUser;
            DateTime dto = System.DateTime.Now;
            string connection = _dapperContext.ConnectionString;

            using (SqlConnection connect = new SqlConnection(connection))
            {


                // string us = _workContext.CurrentUser.ToString();
                string desc = description; 
                    //"User Logged in is:" + uid.ToString();
                
                
                //string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                //   "Values('" + desc.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";

                string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
                   "Values('" + desc.ToString() + "','" + (uid).ToString() + "','" + dto.ToString() + "')";




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


        //public void Klog(long id, string description)
        //{
        //    DateTime dto = System.DateTime.Now;
        //    //string constr = ConfigurationManager.ConnectionStrings();


        //    var user = _workContext.CurrentUser;
        //    string connection = _dapperContext.ConnectionString;
        //    if (description == "C")
        //    {

        //        using (SqlConnection connect = new SqlConnection(connection))
        //        {


        //            // string us = _workContext.CurrentUser.ToString();
        //            string desc = "City Created where Id is:" + id.ToString();
        //            string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
        //               "Values('" + desc.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";





        //            //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

        //            //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


        //            SqlCommand command = new SqlCommand(query, connect);



        //            connect.Open();

        //            //string des = (string)onlyonedesc.ExecuteScalar();
        //            //h = des;
        //            //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
        //            //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

        //            //SqlCommand command1 = new SqlCommand(query1, connect);

        //            //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
        //            //string CustomerName = (string)CmdName.ExecuteScalar();

        //            command.ExecuteNonQuery();

        //            connect.Close();

        //        }

        //    }
        //    else if (description == "M")
        //    {
        //        using (SqlConnection connect = new SqlConnection(connection))
        //        {

        //            // string us = _workContext.CurrentUser.ToString();
        //            string desc = "City Modified Id is:" + id.ToString();
        //            string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
        //                "Values('" + desc.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";

        //            //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

        //            //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


        //            SqlCommand command = new SqlCommand(query, connect);
        //            connect.Open();

        //            //string des = (string)onlyonedesc.ExecuteScalar();
        //            //h = des;
        //            //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
        //            //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

        //            //SqlCommand command1 = new SqlCommand(query1, connect);

        //            //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
        //            //string CustomerName = (string)CmdName.ExecuteScalar();

        //            command.ExecuteNonQuery();
        //            connect.Close();

        //        }

        //    }
        //    else if (description == "D")
        //    {
        //        using (SqlConnection connect = new SqlConnection(connection))
        //        {


        //            // string us = _workContext.CurrentUser.ToString();
        //            string desc = "City Deleted Where Id is:" + id.ToString();
        //            string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
        //                "Values('" + desc.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";

        //            //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

        //            //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


        //            SqlCommand command = new SqlCommand(query, connect);
        //            connect.Open();

        //            //string des = (string)onlyonedesc.ExecuteScalar();
        //            //h = des;
        //            //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
        //            //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

        //            //SqlCommand command1 = new SqlCommand(query1, connect);

        //            //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
        //            //string CustomerName = (string)CmdName.ExecuteScalar();

        //            command.ExecuteNonQuery();
        //            connect.Close();

        //        }

        //    }
        //    else if (id == 1 && description == "V")
        //    {
        //        using (SqlConnection connect = new SqlConnection(connection))
        //        {



        //            string desc = "City Viewed List";
        //            string query = "Insert into UserActivityLogs ([Description],[UserId],[CreatedLogTime])" +
        //                "Values('" + desc.ToString() + "','" + (user.Name).ToString() + "','" + dto.ToString() + "')";

        //            //string onlyone="Select Description from UserActivityLogs where Description ='"+id+"'";

        //            //SqlCommand onlyonedesc = new SqlCommand(onlyone, connect);


        //            SqlCommand command = new SqlCommand(query, connect);

        //            connect.Open();

        //            //string des = (string)onlyonedesc.ExecuteScalar();
        //            //h = des;
        //            //string query1 = "Insert into UserActivityLogs (Description,UserId,CreatedLogTime)" +
        //            //    "Values('" + h + "','" + v2 + "','" + v3 + "')";

        //            //SqlCommand command1 = new SqlCommand(query1, connect);

        //            //Int32 CustomerCnt = (Int32)CmdCnt.ExecuteScalar();
        //            //string CustomerName = (string)CmdName.ExecuteScalar();

        //            command.ExecuteNonQuery();
        //            connect.Close();

        //        }
        //        //using (SqlConnection connect = new SqlConnection(connection))
        //        //{

        //        //    string ciname = "Select [Name] from City where id=" + id.ToString();


        //        //    SqlCommand command2 = new SqlCommand(ciname, connect);

        //        //    connect.Open();
        //        //    string city_name = (string)command2.ExecuteScalar();
        //        //    cName = city_name;
        //        //    command2.ExecuteNonQuery();
        //        //    connect.Close();
        //        //}

        //    }

        //}

        #endregion



    }
}
