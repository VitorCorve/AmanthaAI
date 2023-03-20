namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract
{
    internal interface IMentalStatementMediatorsFactory<T> where T : IMentalStatementMediator, new()
    {
        T FactoryMethod();
    }
}
