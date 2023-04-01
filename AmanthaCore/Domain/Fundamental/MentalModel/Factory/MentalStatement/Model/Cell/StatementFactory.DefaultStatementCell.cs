using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementCell"/> interface implementation for architecture building purpose.
        /// </summary>
        private class DefaultStatementCell : IMentalStatementCell
        {
            public IEnumerable<IMentalStatement> Statements { get; private set; }

            public IMentalStatementMediator? Mediator { get; private set; }

            internal DefaultStatementCell()
            {
                Statements = new List<IMentalStatement>();
                Logger.Log();
            }

            public void Entropy<T>(T source)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                Logger.Log(stamp);
            }

            public void InitializeMediator(IMentalStatementMediator mediator)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                Mediator = mediator;

                Logger.Log(stamp);
            }

            public void InitializeStatement(IMentalStatement statement)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                if (Statements is List<IMentalStatement> list)
                {
                    list.Add(statement);
                }

                Logger.Log(stamp);
            }
        }
    }
}