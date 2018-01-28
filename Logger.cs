using System;
using System.IO;

/// <summary>
/// Static logger class that allows direct logging of anything to a text file
/// </summary>
static class Logger
{
    private static string logFileName = "iFruitAddon2.log";

    public static void Log(object message)
    {
        File.AppendAllText(logFileName, DateTime.Now + " : " + message + Environment.NewLine);
    }
}