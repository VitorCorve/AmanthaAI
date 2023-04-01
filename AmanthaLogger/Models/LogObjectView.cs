namespace AmanthaLogger.Models
{
    /// <summary>
    /// Fabric class to provide Key-Value dictionaries creation.
    /// </summary>
    public static class LogObjectView
    {
        /// <summary>
        /// Creates a dictionary with key-value pairs, received from <see cref="LogObject"/> entity.
        /// </summary>
        /// <param name="logObject"></param>
        /// <returns></returns>
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
                { nameof(logObject.MemoryUsage), logObject.MemoryUsage.ToString() + " MB" },
                { nameof(logObject.StackTrace), logObject.StackTrace?.ToString() }
            };

            return pairs;
        }
    }
}
