using AmanthaRuntimeLoggingConsole.Services;

namespace AmanthaRuntimeLoggingConsole;

public class Program
{
    public static void Main(string[] args)
    {
        PipeServer server = new();
        server.Listen();
    }
}