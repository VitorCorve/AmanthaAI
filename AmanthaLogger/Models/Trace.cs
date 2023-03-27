using System.Reflection;

namespace AmanthaLogger.Models
{
    internal class Trace
    {
        internal string Type { get; set; }
        internal string Method { get; set; }
        internal Trace(MethodBase calledMethod)
        {
            Type = calledMethod.ReflectedType?.Name ?? "Undefined";
            Method = calledMethod.Name;
        }

        internal Trace()
        {
            Type = "Undefined";
            Method = "Undefined";
        }
    }
}
