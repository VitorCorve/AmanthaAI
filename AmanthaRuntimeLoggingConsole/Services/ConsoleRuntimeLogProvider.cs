namespace AmanthaRuntimeLoggingConsole.Services
{
    internal class ConsoleRuntimeLogProvider
    {
        static ConsoleRuntimeLogProvider()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
        }

        public static void Log(Dictionary<string, string?> view)
        {
            Console.WriteLine("\r--------Execution--------");

            foreach (var key in view.Keys)
                Console.WriteLine($"{key}: {view[key]}");
        }
    }
}
