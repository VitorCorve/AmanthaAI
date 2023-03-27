using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Services
{
    internal class MentalStatementMediatorsFactory : IMentalStatementMediatorsFactory
    {
        public T FactoryMethod<T>() where T : class, IMentalStatementMediator, new()
        {
            PerformanceStamp stamp = Logger.CreateStamp();

            Logger.Log(stamp);

            return new T();
        }
    }
}
