using AmanthaRuntimeLoggingConsole.Services;

namespace AmanthaRuntimeLoggingConsole;

public class Program
{
    public static void Main(string[] args)
    {
        using PipeServer server = new();
        server.Listen();
    }
}