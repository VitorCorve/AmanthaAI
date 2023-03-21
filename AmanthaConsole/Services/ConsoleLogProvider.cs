using AmanthaLogger.Interfaces;
using AmanthaLogger.Models;

using System.IO.Pipes;

namespace AmanthaConsole.Services
{
    internal class ConsoleLogProvider : ILoggingProvider
    {
        public Guid ID { get; private set; }
        private NamedPipeClientStream _pipeClient;

        internal ConsoleLogProvider()
        {
            ID = Guid.NewGuid();

            _pipeClient = new NamedPipeClientStream(".", "amanthaPipeServer", PipeDirection.Out);
            _pipeClient.Connect();
        }

        public void Provide(LogObject log)
        {
            Dictionary<string, string?> view = LogObjectView.Create(log);

            byte[] bytes = System.Text.Json.JsonSerializer.SerializeToUtf8Bytes(view);

            _pipeClient.Write(bytes);
            _pipeClient.Flush();
        }

        internal void Dispose()
        {
            _pipeClient?.Dispose();
        }
    }
}
