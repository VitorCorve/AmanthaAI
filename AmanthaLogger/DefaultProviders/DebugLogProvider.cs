using AmanthaLogger.Interfaces;
using AmanthaLogger.Models;

namespace AmanthaLogger.DefaultProviders
{
    /// <summary>
    /// Default <see cref="ILoggingProvider"/> implementation to drop logs into Debug output.
    /// </summary>
    public class DebugLogProvider : ILoggingProvider
    {
        private static DebugLogProvider? _instance;
        private readonly static object _lock = new();

        public static DebugLogProvider Instance
        {
            get
            {
                lock (_lock)
                {
                    _instance ??= new DebugLogProvider();
                    return _instance;
                }
            }
        }

        private DebugLogProvider()
        {
            ID = Guid.NewGuid();
        }

        public Guid ID { get; private set; }

        public void Provide(LogObject log)
        {
            System.Diagnostics.Debug.WriteLine("\r--------Execution--------");
            System.Diagnostics.Debug.WriteLine($"Date: {log.Date:HH:mm:ss dd.MM.yy}");
            System.Diagnostics.Debug.WriteLine($"Class name: {log.File}");
            System.Diagnostics.Debug.WriteLine($"Assembly name: {log.AssemblyName}");
            System.Diagnostics.Debug.WriteLine($"Line: {log.Line}");
            System.Diagnostics.Debug.WriteLine($"Method name: {log.MethodName}");
            System.Diagnostics.Debug.WriteLine($"Performance time: {log.PerformanceTime} ms");
            System.Diagnostics.Debug.WriteLine($"Memory usage: {log.MemoryUsage} mb");
            System.Diagnostics.Debug.WriteLine($"StackTrace: {log.StackTrace} mb");
        }
    }
}
