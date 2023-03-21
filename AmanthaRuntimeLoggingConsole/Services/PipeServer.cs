using System.IO.Pipes;

namespace AmanthaRuntimeLoggingConsole.Services
{
    internal class PipeServer : IDisposable
    {
        private NamedPipeServerStream _pipeServerStream;
        private readonly byte[] _buffer = new byte[1024];

        internal PipeServer()
        {
            _pipeServerStream = new NamedPipeServerStream("amanthaPipeServer", PipeDirection.In, 1, PipeTransmissionMode.Byte);
        }

        internal void Listen()
        {
            _pipeServerStream.WaitForConnection();

            while (true)
            {
                int length = _pipeServerStream.Read(_buffer, 0, _buffer.Length);

                byte[] result = new byte[length];

                Array.Copy(_buffer, result, length);

                Dictionary<string, string?> view = System.Text.Json.JsonSerializer.Deserialize<Dictionary<string, string?>>(result);

                if (view != null)
                    ConsoleRuntimeLogProvider.Log(view);
            }
        }

        public void Dispose()
        {
            _pipeServerStream?.Close();
            _pipeServerStream?.Dispose();
        }
    }
}
