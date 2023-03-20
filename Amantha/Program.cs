using AmanthaConsole.Services;
using AmanthaLogger;
using AmanthaLogger.Models;

using System.Reflection;

namespace AmanthaConsole;

public class Program
{
    public static void Main(string[] args)
    {
        #if DEBUG
        ConsoleLogProvider logProvider = new();
        Logger.Start(logProvider);
        #endif

        DetermineVersions();

        Console.ReadLine();
    }

    #pragma warning disable CS8602 // Dereference of a possibly null reference.
    /// <summary>
    /// Determine affected assemblies versions.
    /// </summary>
    private static void DetermineVersions()
    {
        #if DEBUG
        PerformanceStamp stamp = Logger.CreateStamp();
        #endif

        Console.ForegroundColor = ConsoleColor.DarkRed;

        Assembly amanthaCore = Assembly.Load("AmanthaCore");
        Assembly amanthaLogger = Assembly.Load("AmanthaLogger");

        string amanthaCoreVersion = $"AmanthaCore: {amanthaCore.FullName.Split(",")[1]}";
        string amanthaLoggerVersion = $"AmanthaLogger: {amanthaLogger.FullName.Split(",")[1]}";

        Console.WriteLine(amanthaCoreVersion);
        Console.WriteLine(amanthaLoggerVersion);

        #if DEBUG
        Logger.Log(stamp);
        #endif
    }
    #pragma warning restore CS8602 // Dereference of a possibly null reference.
}