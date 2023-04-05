using AmanthaConsole.Services;

using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Common;

using AmanthaLogger;
using AmanthaLogger.DefaultProviders;
using AmanthaLogger.Models;
using System.Reflection;

namespace AmanthaConsole;

public class Program
{

    public static void Main(string[] args)
    {
        ConsoleLogProvider logProvider = new();

        Logger.Start(logProvider);
        Logger.Start(DebugLogProvider.Instance);

        DetermineVersions();

        MentalSharingInterface sharingInterface = new();

        IEnumerable<IMentalStatementView> statementInfo = sharingInterface.GetStatement();

        Console.WriteLine();

        foreach (var info in statementInfo)
            Console.WriteLine($"Type: {info.Type}\t Magnitude: {info.Magnitude}");

        Logger.Log();

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