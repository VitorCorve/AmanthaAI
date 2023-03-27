using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors
{
    /// <summary>
    /// Mental statement mediator provides affectance on <see cref="IMentalStatement"/> statements.
    /// Affectance means changing <see cref="IMentalStatement"/> statement, depending on mediator type.
    /// <param></param>
    /// </summary>
    internal interface IMentalStatementMediator
    {
        /// <summary>
        /// Affects to <see cref="IMentalStatement"/> statement.
        /// </summary>
        /// <param name="statement"></param>
        internal void Affect(IMentalStatement statement);
    }
}
