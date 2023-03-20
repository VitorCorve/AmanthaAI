using System.IO.Pipes;

namespace AmanthaRuntimeLoggingConsole.Services
{
    internal class PipeServer : IDisposable
    {
        private NamedPipeServerStream _pipeServerStream;
        private StreamReader _reader;

        public PipeServer()
        {
            _pipeServerStream = new NamedPipeServerStream("amanthaPipeServer", PipeDirection.In);
            _reader = new StreamReader(_pipeServerStream);
        }
        internal void Listen()
        {
            _pipeServerStream.WaitForConnection();

            string temp = string.Empty;

            while (true)
            {
                temp = _reader.ReadLine();

                if (!string.IsNullOrEmpty(temp))
                    ConsoleRuntimeLogProvider.Instance.Log(temp);
            }
        }

        public void Dispose()
        {
            if (_pipeServerStream != null)
            {
                _pipeServerStream.Close();
                _pipeServerStream?.Dispose();
                _reader?.Dispose();
            }
        }
    }
}
