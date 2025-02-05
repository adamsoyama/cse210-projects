using System;
using System.IO;

public static class Log
{
    private static string logFilePath = "activity_log.txt";

    public static void LogActivity(string activityName, int duration)
    {
        string logEntry = $"{DateTime.Now}: {activityName} - {duration} seconds";
        File.AppendAllText(logFilePath, logEntry + Environment.NewLine);
    }

    public static void DisplayLog()
    {
        if (File.Exists(logFilePath))
        {
            string[] logEntries = File.ReadAllLines(logFilePath);
            foreach (string logEntry in logEntries)
            {
                Console.WriteLine(logEntry);
            }
        }
        else
        {
            Console.WriteLine("No log entries found.");
        }
    }
}
