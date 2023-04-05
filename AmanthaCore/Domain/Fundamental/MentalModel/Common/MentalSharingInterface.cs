using AmanthaCore.Domain.Fundamental.Abstractions.Factory;
using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Common
{
    public class MentalSharingInterface
    {
        private IMentalStatementManager _manager;
        public MentalSharingInterface()
        {
            _manager = StatementFactory.FactoryMethod(MentalStatementManagerType.Default);

            _manager.ReceiveEntropySource(new object());

            Logger.Log();
        }

        public IEnumerable<IMentalStatementView> GetStatement()
        {
            return _manager.GetStatement();
        }
    }
}
