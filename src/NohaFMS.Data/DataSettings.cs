/*******************************************************
 * Copyright 2019 (C) Teknoloje Solutions
 * All Rights Reserved
*******************************************************/
using System.Configuration;

namespace NohaFMS.Data
{
    public static class DataSettings
    {
        public static string DataProvider = ConfigurationManager.ConnectionStrings["NohaFMS"].ProviderName;
        public static string ConnectionString = ConfigurationManager.ConnectionStrings["NohaFMS"].ConnectionString;
    }
}
