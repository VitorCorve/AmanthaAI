using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    /// <summary>
    /// Mental statement builder. Allows to easely build an <see cref="IMentalStatement"/> with required <see cref="IMentalStatementProperty"/> properties.
    /// </summary>
    /// <typeparam name="IMentalStatement"></typeparam>
    internal interface IMentalStatementBuilder
    {
        /// <summary>
        /// Applies <see cref="IMentalStatementProperty"/> over <see cref= "IMentalStatement" />.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        internal IMentalStatementBuilder ApplyProperty(IMentalStatementProperty property);

        /// <summary>
        /// Builds an <see cref="IMentalStatement"/> with depended <see cref="IMentalStatementProperty"/> and selected <see cref="MentalStatementType"/>.
        /// </summary>
        /// <returns></returns>
        internal IMentalStatement Build(MentalStatementType type);
    }
}
