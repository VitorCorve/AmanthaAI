using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    /// <summary>
    /// Mediators factory for short <see cref="IMentalStatementMediator"/> creation.
    /// </summary>
    internal interface IMentalStatementMediatorsFactory
    {
        /// <summary>
        /// A factory method.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        internal T FactoryMethod<T>() where T : class, IMentalStatementMediator, new();
    }
}
