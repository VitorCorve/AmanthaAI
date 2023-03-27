using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    /// <summary>
    /// Mental statement builder. Allows to easely build an <see cref="IMentalStatement"/> with required <see cref="IMentalStatementProperty"/> properties.
    /// </summary>
    /// <typeparam name="IMentalStatement"></typeparam>
    internal interface IMentalStatementBuilder<IMentalStatement>
    {
        /// <summary>
        /// This builder contains <see cref="IMentalStatement"/> incapsulated entity inside.
        /// Every each <see cref="ApplyProperty(IMentalStatementProperty)"/> invokation will call inner
        /// ApplyProperty of <see cref="IMentalStatement"/> and increase properties count, untill it will be builded.
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        internal IMentalStatementBuilder<IMentalStatement> ApplyProperty(IMentalStatementProperty property);

        /// <summary>
        /// Builds an <see cref="IMentalStatement"/> with depended <see cref="IMentalStatementProperty"/>.
        /// </summary>
        /// <returns></returns>
        internal IMentalStatement Build();
    }
}
