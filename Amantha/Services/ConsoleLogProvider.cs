using AmanthaLogger.Interfaces;
using AmanthaLogger.Models;

namespace AmanthaConsole.Services
{
    internal class ConsoleLogProvider : ILoggingProvider
    {
        public Guid ID { get; private set; }

        public ConsoleLogProvider()
        {
            ID = Guid.NewGuid();
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public void Provide(LogObject log)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\r--------Execution--------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"Date: {log.Date:HH:mm:ss dd.MM.yy}\r");
            Console.WriteLine($"Class name: {log.File}\r");
            Console.WriteLine($"Assembly name: {log.AssemblyName}\r");
            Console.WriteLine($"Line: {log.Line}\r");
            Console.WriteLine($"Method name: {log.MethodName}\r");
            Console.WriteLine($"Performance time: {log.PerformanceTime} ms\r");
            Console.WriteLine($"Memory usage: {log.MemoryUsage} mb\r");
        }
    }
}
