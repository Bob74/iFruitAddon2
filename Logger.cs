using System;
using System.IO;

/// <summary>
/// Static logger class that allows direct logging of anything to a text file
/// </summary>
/// 
namespace iFruitAddon2
{ 
    static class Logger
    {
        private static readonly string logFileName = "iFruitAddon2.log";

        public static void ResetLogFile()
        {
            FileStream fs = File.Create(logFileName);
            fs.Close();
        }
        public static void Debug(object message)
        {
            if (iFruitAddon2.IsDebug)
            {
                Log("Debug - " + Tools.GetCurrentMethod(1) + " " + message);
            }
        }
        public static void Info(object message)
        {
            Log("Info - " + message);
        }
        public static void Warning(object message)
        {
            Log("Warning - " + message);
        }
        public static void Error(object message)
        {
            Log("Error - " + Tools.GetCurrentMethod(1) + " " + message);
        }
        public static void Exception(Exception ex)
        {
            Log("Exception - " + ex.Message + "\r\n" + ex.StackTrace);
        }

        private static void Log(object message)
        {
            File.AppendAllText(logFileName, DateTime.Now + " : " + message + Environment.NewLine);
        }
    }

}