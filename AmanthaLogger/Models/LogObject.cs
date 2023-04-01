using System.Diagnostics;
using System.Reflection;

namespace AmanthaLogger.Models
{
    /// <summary>
    /// Base log object.
    /// </summary>
    sealed public class LogObject
    {
        /// <summary>
        /// Event date.
        /// </summary>
        public DateTime Date;

        /// <summary>
        /// Class name.
        /// </summary>
        public string? File;

        /// <summary>
        /// Assembly name.
        /// </summary>
        public string? AssemblyName;

        /// <summary>
        /// Method (caller) name.
        /// </summary>
        public string? MethodName;

        /// <summary>
        /// Performance time (optional if <see cref="PerformanceStamp"/> was not requested).
        /// </summary>
        public double? PerformanceTime;

        /// <summary>
        /// Line itself.
        /// </summary>
        public int? Line;

        /// <summary>
        /// Application memory usage at <see cref="LogObject"/> constructor initialization moment.
        /// </summary>
        public long MemoryUsage;

        /// <summary>
        /// Call stack.
        /// </summary>
        public string? StackTrace;

        internal LogObject(DateTime date, string? file, string? assemblyName, string? methodName, double? performanceTime, int? line)
        {
            StackTrace = BuildTrace();
            Date = date;
            File = file;
            AssemblyName = assemblyName;
            MethodName = methodName;
            PerformanceTime = performanceTime;
            Line = line;
            MemoryUsage = GC.GetTotalAllocatedBytes(false) / 1024 / 1024;
        }

        private string BuildTrace()
        {
            StackTrace callStack = new();

            if (callStack.FrameCount > 3)
            {
                Trace[] parameters = new Trace[callStack.FrameCount];

                int index = 0;

                for (int i = callStack.FrameCount; i > 2; i--)
                {
                    MethodBase calledMethod = callStack.GetFrame(i)?.GetMethod();

                    if (calledMethod is null || calledMethod.DeclaringType is null)
                    {
                        continue;
                    }
                    else
                    {
                        parameters[index] = new Trace(calledMethod);
                        index++;
                    }
                }

                return string.Join("/", parameters
                    .Where(trace => trace is not null)
                    .Take(5)
                    .Select(trace => $"{trace.Type}.{trace.Method}"));
            }

            throw new Exception("Frames count lower than 3. Check AmanthaLogger.LogObject.BuildTrace");
        }
    }
}
