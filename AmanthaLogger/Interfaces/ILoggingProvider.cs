using AmanthaLogger.Models;

namespace AmanthaLogger.Interfaces
{
    public interface ILoggingProvider
    {
        public Guid ID { get; }
        public void Provide(LogObject log);
    }
}
