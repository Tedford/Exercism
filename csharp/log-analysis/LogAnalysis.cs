using System;

public static class LogAnalysis
{
    public static string SubstringAfter(this string message, string delimter)
    {
        return message.Substring(message.IndexOf(delimter) + delimter.Length);
    }

    public static string SubstringBetween(this string message, string start, string end)
    {
        var startIndex = message.IndexOf(start) + start.Length;
        var endIndex = message.LastIndexOf(end);
        return message[startIndex .. endIndex];
    }

    public static string Message(this string message) => message.SubstringAfter(": ");

    public static string LogLevel(this string message) => message.Split(':')[0][1..^1];
}