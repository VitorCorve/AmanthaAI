namespace AmanthaRuntimeLoggingConsole.Services
{
    internal class ConsoleRuntimeLogProvider
    {
        private static ConsoleRuntimeLogProvider? _instance;
        private static object _instanceLock = new();

        static ConsoleRuntimeLogProvider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static ConsoleRuntimeLogProvider Instance
        {
            get
            {
                lock (_instanceLock)
                    _instance ??= new ConsoleRuntimeLogProvider();

                return _instance;
            }
        }

        public void Log(string view)
        {
            Console.WriteLine(view);
        }
    }
}
