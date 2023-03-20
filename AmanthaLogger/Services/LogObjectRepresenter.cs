using AmanthaLogger.Models;

using System.Text;

namespace AmanthaLogger.Services
{
    public class LogObjectRepresenter
    {
        private static readonly StringBuilder _builder = new();

        public static string Stringify(LogObject log)
        {
            _builder.Clear();

            _builder.AppendLine("\r--------Execution--------");
            _builder.AppendLine($"Date: {log.Date}");
            _builder.AppendLine($"File: {log.File}");
            _builder.AppendLine($"AssemblyName: {log.AssemblyName}");
            _builder.AppendLine($"MethodName: {log.MethodName}");
            _builder.AppendLine($"PerformanceTime: {log.PerformanceTime}");
            _builder.AppendLine($"Line: {log.Line}");
            _builder.AppendLine($"MemoryUsage: {log.MemoryUsage}");

            return _builder.ToString();
        }
    }
}
