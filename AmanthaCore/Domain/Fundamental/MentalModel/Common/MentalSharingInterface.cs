using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Services;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Common
{
    public class MentalSharingInterface
    {
        public MentalSharingInterface()
        {
            MentalStatementManager manager = new();

            IMentalStatementBuilder<IMentalStatement> builder = new MentalStatementBuilder<MentalStatement>();

            IMentalStatementMediatorsFactory mediatorsFactory = new MentalStatementMediatorsFactory();

            IMentalStatementMediator mediator = mediatorsFactory.FactoryMethod<MentalStatementMediator>();

            IMentalStatementCell[] cells = new IMentalStatementCell[5];

            for (int i = 0; i < 5; i++)
            {
                IMentalStatementCell cell = new MentalStatementCell();

                cell.InitializeStatement(builder);
                cell.InitializeMediator(mediator);

                cells[i] = cell;
            }

            manager.InitializeCells(cells);
            manager.ReceiveEntropySource(new object());

            Logger.Log();
        }
    }
}
