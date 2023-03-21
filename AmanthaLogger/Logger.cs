using AmanthaLogger.Interfaces;
using AmanthaLogger.Models;

using System.Reflection;
using System.Runtime.CompilerServices;

namespace AmanthaLogger
{
    /// <summary>
    /// Logger service.
    /// </summary>
    public static class Logger
    {
        private static bool _logging;
        private static List<ILoggingProvider> _providers = new();
        private static List<PerformanceStamp> _stamps = new();

        /// <summary>
        /// Register <see cref="ILoggingProvider"/> instance if not exists. Else, will throw an error.
        /// </summary>
        /// <param name="provider"></param>
        /// <exception cref="Exception"></exception>
        public static void Start(ILoggingProvider provider)
        {
            if (_providers.Any(x => x.ID.Equals(provider.ID)))
                throw new Exception($"Provider with id {provider.ID} from type {provider.GetType()} already exists");

            else
            {
                _providers.Add(provider);
                _logging = _providers.Any();
            }
        }

        /// <summary>
        /// Detach <see cref="ILoggingProvider"/> instance if exists. Else, will throw an error.
        /// </summary>
        /// <param name="provider"></param>
        /// <exception cref="Exception"></exception>
        public static void Stop(ILoggingProvider provider)
        {
            if (_providers.Any(x => x.ID.Equals(provider.ID)))
            {
                _providers.Remove(provider);
                _logging = _providers.Any();
            }
            else
                throw new Exception($"Unable to find provider with id {provider.ID} from type {provider.GetType()}");
        }


        /// <summary>
        /// Log method name, file, assembly name, line. Passes <see cref="LogObject"/> to each registered <see cref="ILoggingProvider"/>.
        /// </summary>
        /// <param name="methodName"></param>
        /// <param name="file"></param>
        /// <param name="line"></param>
        public static void Log([CallerMemberName] string? methodName = null, [CallerFilePath] string? file = null, [CallerLineNumber] int? line = null)
        {
            if (_logging)
            {
                LogObject log = new(
                    date: DateTime.Now,
                    file: file,
                    assemblyName: Assembly.GetCallingAssembly().FullName,
                    methodName: methodName,
                    performanceTime: 0.0,
                    line: line);

                foreach (var provider in _providers)
                    provider.Provide(log);
            }
        }

        /// <summary>
        /// Log data with <see cref="PerformanceStamp"/>. 
        /// Logs method name, file name, assembly name, performance time, line. Passes <see cref="LogObject"/> to each registered <see cref="ILoggingProvider"/>.
        /// </summary>
        /// <param name="stamp"></param>
        /// <param name="methodName"></param>
        /// <param name="file"></param>
        /// <param name="line"></param>
        public static void Log(PerformanceStamp stamp, [CallerMemberName] string? methodName = null, [CallerFilePath] string? file = null, [CallerLineNumber] int? line = null)
        {
            if (_logging)
            {
                PerformanceStamp? match = _stamps.FirstOrDefault(x => x.ID == stamp.ID);

                LogObject log = new(
                    date: DateTime.Now,
                    file: file,
                    assemblyName: Assembly.GetCallingAssembly().FullName,
                    methodName: methodName,
                    performanceTime: match is null ? 0.0 : (DateTime.Now - match.DateCreated).TotalSeconds,
                    line: line);

                if (match != null)
                    _stamps.Remove(match);

                foreach (var provider in _providers)
                    provider.Provide(log);
            }
        }

        /// <summary>
        /// Creates performance stamp.
        /// </summary>
        /// <returns></returns>
        public static PerformanceStamp CreateStamp([CallerMemberName] string? methodName = null, [CallerFilePath] string? file = null)
        {
            PerformanceStamp token = new(methodName, file);
            _stamps.Add(token);
            return token;
        }
    }
}
