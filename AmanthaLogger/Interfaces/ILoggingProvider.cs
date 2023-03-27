using AmanthaLogger.Models;

namespace AmanthaLogger.Interfaces
{
    /// <summary>
    /// Logger entity presentation interface. Every logger service should implement <see cref="ID"/> to be managed,
    /// and <see cref="Provide(LogObject)"/> method to provide logging implementation.
    /// </summary>
    public interface ILoggingProvider
    {
        /// <summary>
        /// Uniqual identifier.
        /// </summary>
        public Guid ID { get; }

        /// <summary>
        /// Log providing method.
        /// </summary>
        /// <param name="log"></param>
        public void Provide(LogObject log);
    }
}
