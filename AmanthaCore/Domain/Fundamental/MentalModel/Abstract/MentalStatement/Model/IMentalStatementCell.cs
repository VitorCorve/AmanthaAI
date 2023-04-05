using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    /// <summary>
    /// Mental statement cell, which contains relationships between <see cref="Statements"/> collections and <see cref="Mediator"/>.
    /// <param></param>
    /// Should incapsulate and implement relations between <see cref="IMentalStatement"/> and <see cref="IMentalStatementMediator"/>.
    /// For example: how mediator affects to the statements; which statements are able to be affected;
    /// </summary>
    internal interface IMentalStatementCell
    {
        /// <summary>
        /// Statements collection. Should be available for reading only.
        /// </summary>
        internal IEnumerable<IMentalStatement> Statements { get; }

        /// <summary>
        /// Mediator itself. Should be available for reading only.
        /// </summary>
        internal IMentalStatementMediator Mediator { get; }

        /// <summary>
        /// Initializes statement.
        /// </summary>
        /// <param name="statement"></param>
        internal void InitializeStatement(IMentalStatement statement);

        /// <summary>
        /// Initializes mediator.
        /// </summary>
        /// <param name="mediator"></param>
        internal void InitializeMediator(IMentalStatementMediator mediator);

        /// <summary>
        /// Call entropy to invoke mediator for affecting statements purpose. Requires <paramref name="source"/> to be invoken within.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        internal void Entropy<T>(T source);
    }
}
