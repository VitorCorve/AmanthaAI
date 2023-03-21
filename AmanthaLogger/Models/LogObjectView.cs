namespace AmanthaLogger.Models
{
    public class LogObjectView
    {
        public static Dictionary<string, string?> Create(LogObject logObject)
        {
            Dictionary<string, string?> pairs = new()
            {
                { nameof(logObject.AssemblyName), logObject.AssemblyName },
                { nameof(logObject.Date), logObject.Date.ToString() },
                { nameof(logObject.File), logObject.File },
                { nameof(logObject.MethodName), logObject.MethodName },
                { nameof(logObject.PerformanceTime), logObject.PerformanceTime.ToString() },
                { nameof(logObject.Line), logObject.MemoryUsage.ToString() },
                { nameof(logObject.MemoryUsage), logObject.MemoryUsage.ToString() }
            };

            return pairs;
        }
    }
}
