namespace AmanthaLogger.Models
{
    sealed public class LogObject
    {
        public DateTime Date;
        public string? File;
        public string? AssemblyName;
        public string? MethodName;
        public double? PerformanceTime;
        public int? Line;
        public long MemoryUsage;

        internal LogObject(DateTime date, string? file, string? assemblyName, string? methodName, double? performanceTime, int? line)
        {
            Date = date;
            File = file;
            AssemblyName = assemblyName;
            MethodName = methodName;
            PerformanceTime = performanceTime;
            Line = line;
            MemoryUsage = GC.GetTotalMemory(false) / 1024 / 1024;
        }
    }
}
