using System;
using System.IO;

namespace iFruitAddon2
{
    /// <summary>
    /// Static logger class that allows direct logging of anything to a text file
    /// </summary>
    static class Logger
    {
        private static readonly string logFileName = "iFruitAddon2.log";

        internal static void ResetLogFile()
        {
            FileStream fs = File.Create(logFileName);
            fs.Close();
        }
        internal static void Debug(object message)
        {
            if (iFruitAddon2.IsDebug)
            {
                Log("Debug - " + Tools.GetCurrentMethod(1) + " " + message);
            }
        }
        internal static void Info(object message)
        {
            Log("Info - " + message);
        }
        internal static void Warning(object message)
        {
            Log("Warning - " + message);
        }
        internal static void Error(object message)
        {
            Log("Error - " + Tools.GetCurrentMethod(1) + " " + message);
        }
        internal static void Exception(Exception ex)
        {
            Log("Exception - " + ex.Message + Environment.NewLine + ex.StackTrace);
        }

        private static void Log(object message)
        {
            File.AppendAllText(logFileName, DateTime.Now + " : " + message + Environment.NewLine);
        }
    }

}