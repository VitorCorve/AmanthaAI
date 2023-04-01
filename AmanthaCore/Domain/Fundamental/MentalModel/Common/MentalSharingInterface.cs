using AmanthaCore.Domain.Fundamental.Abstractions.Factory;
using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Common
{
    public class MentalSharingInterface
    {
        public MentalSharingInterface()
        {
            IMentalStatementMediator mediator = StatementFactory.FactoryMethod(MentalStatementMediatorType.Default);

            IMentalStatementCell[] cells = StatementFactory.ArrayFactoryMethod(MentalStatementCellType.Default, 5);

            IMentalStatementBuilder builder = StatementFactory.FactoryMethod(MentalStatementBuilderType.StatementBuilder, MentalStatementType.Default);

            IMentalStatementProperty property = StatementFactory.FactoryMethod(MentalStatementProperty.Default);

            IMentalStatement statement = builder.ApplyProperty(property)
                .Build();

            for (int i = 0; i < 5; i++)
            {
                cells[i].InitializeStatement(statement);
                cells[i].InitializeMediator(mediator);
            }

            IMentalStatementManager manager = StatementFactory.FactoryMethod(MentalStatementManagerType.Default);

            manager.InitializeCells(cells);
            manager.ReceiveEntropySource(new object());

            Logger.Log();
        }
    }
}
