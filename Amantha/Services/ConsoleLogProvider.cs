using AmanthaLogger.Interfaces;
using AmanthaLogger.Models;
using AmanthaLogger.Services;

using System.IO.Pipes;

namespace AmanthaConsole.Services
{
    internal class ConsoleLogProvider : ILoggingProvider
    {
        public Guid ID { get; private set; }
        private StreamWriter _streamWriter;
        private NamedPipeClientStream _pipeClient;

        public ConsoleLogProvider()
        {
            ID = Guid.NewGuid();
            _pipeClient = new NamedPipeClientStream(".", "amanthaPipeServer", PipeDirection.Out);
            _pipeClient.Connect();

            _streamWriter = new StreamWriter(_pipeClient)
            {
                AutoFlush = true
            };
        }

        public void Provide(LogObject log)
        {
            string view = LogObjectRepresenter.Stringify(log);
            _streamWriter.Write(view);
        }
    }
}
