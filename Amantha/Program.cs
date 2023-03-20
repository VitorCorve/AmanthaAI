using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaConsole;

public class Program
{
    public static void Main(string[] args)
    {
        ConsoleLogProvider logProvider = new();

        Logger.Start(logProvider);

        PerformanceStamp stamp = Logger.CreateStamp();

        Logger.Log(stamp);

        Operate();

        Console.ReadLine();
    }

    private static void Operate()
    {
        PerformanceStamp stamp = Logger.CreateStamp();

        List<string> result = new();

        for (int i = 0; i < 100000; i++)
        {
            result.Add(Guid.NewGuid().ToString());
        }

        result.AddRange(result.Where(x => x.StartsWith("x")).ToList());
        result = result.Skip(100)
            .Take(100)
            .Distinct()
            .Skip(100)
            .Take(100)
            .Order()
            .ToList();

        Logger.Log(stamp);
    }
}