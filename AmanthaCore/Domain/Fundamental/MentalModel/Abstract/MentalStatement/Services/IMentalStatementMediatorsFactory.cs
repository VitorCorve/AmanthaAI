using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    internal interface IMentalStatementMediatorsFactory<T> where T : IMentalStatementMediator, new()
    {
        T FactoryMethod();
    }
}
