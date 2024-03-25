using System;
using System.Configuration;
using System.IO;


namespace NohaFMS.Core
{
    public static class ComLogging
    {
        public static void logger(string message, int Found)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            logPath = logPath + System.DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{ DateTime.Now } {message} {Found}");
            }

        }
        public static void logger(string message)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            logPath = logPath + System.DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{ DateTime.Now } {message}");
            }

        }
        public static void logger(string message, string message1, int Found)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            logPath = logPath + System.DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{ DateTime.Now } {message} {message1}{Found}");
            }
        }
        public static void logger(string message, string message1)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            logPath = logPath + System.DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{ DateTime.Now } {message} {message1}");
            }
        }
        public static void logger(string message, string[] str)
        {
            string logPath = ConfigurationManager.AppSettings["logPath"];
            logPath = logPath + System.DateTime.Today.ToString("yyyyMMdd") + "." + "txt";

            using (StreamWriter writer = new StreamWriter(logPath, true))
            {
                writer.WriteLine($"{ DateTime.Now } {message} {str}");
            }
        }
    }
}
