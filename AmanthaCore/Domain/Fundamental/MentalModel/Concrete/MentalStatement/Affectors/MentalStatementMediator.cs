using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Affectors
{
    internal class MentalStatementMediator : IMentalStatementMediator
    {
        public MentalStatementMediator()
        {
            Logger.Log();
        }
        public void Affect(IMentalStatement statement)
        {
            PerformanceStamp stamp = Logger.CreateStamp();

            Logger.Log(stamp);
        }
    }
}
