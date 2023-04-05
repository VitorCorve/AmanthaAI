using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

using AmanthaDotnetExtensions;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementMediator"/> interface implementation for architecture building purpose.
        /// </summary>
        private class PainMediator : IMentalStatementMediator
        {
            public MentalStatementMediatorType Type { get; } = MentalStatementMediatorType.Pain;

            public void Affect(IMentalStatement statement)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                #if DEBUG
                Debug_AffectRandomly(statement);
                #endif

                Logger.Log(stamp);
            }

            private static void Debug_AffectRandomly(IMentalStatement statement)
            {
                Random rand = new();

                PerformanceStamp stamp = Logger.CreateStamp();

                statement.Properties.ForEach(p => p.ChangeMagnitude(rand.Next(0, 10)));

                Logger.Log(stamp);
            }
        }
    }
}
