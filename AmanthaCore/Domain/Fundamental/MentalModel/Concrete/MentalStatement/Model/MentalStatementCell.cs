using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Model
{
    internal class MentalStatementCell : IMentalStatementCell
    {
        public IEnumerable<IMentalStatement> Statements { get; private set; }

        public IMentalStatementMediator? Mediator { get; private set; }

        internal MentalStatementCell()
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

        public void InitializeStatement(IMentalStatementBuilder<IMentalStatement> builder)
        {
            PerformanceStamp stamp = Logger.CreateStamp();

            if (Statements is List<IMentalStatement> list)
            {
                IMentalStatement statement = builder.ApplyProperty(new ConcreteStatementProperty())
                    .Build();

                list.Add(statement);
            }

            Logger.Log(stamp);
        }
    }
}