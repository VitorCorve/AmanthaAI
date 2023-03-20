using System.Runtime.CompilerServices;

namespace AmanthaLogger.Models
{
    /// <summary>
    /// Performance stamp. Contains DateCreated, Caller name and class name and ID as <see cref="Guid"/>.
    /// </summary>
    public class PerformanceStamp
    {
        internal DateTime DateCreated;
        internal Guid ID;
        internal string? MethodName;
        internal string? File;
        internal PerformanceStamp(string? methodName, string? file)
        {
            DateCreated = DateTime.Now;
            MethodName = methodName;
            File = file;
            ID = Guid.NewGuid();
        }
    }
}
