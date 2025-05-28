using System.ComponentModel;
using Microsoft.SemanticKernel;

namespace SemanticKernelPlugins.Plugins;

public class TimeInformationPlugin
{
    [KernelFunction]
    [Description("Retrieves the current time and day in CET from germany.")]
    public string GetCurrentTimeAndDay()
    {
        var cetZone = TimeZoneInfo.FindSystemTimeZoneById("Central European Standard Time");
        var germanTime = TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, cetZone);

        var time = germanTime.ToString("HH:mm:ss");
        var dayOfWeek = germanTime.ToString("dddd", new System.Globalization.CultureInfo("de-DE"));

        return $"Current time in germany: {time}, day: {dayOfWeek}";
    }
}
