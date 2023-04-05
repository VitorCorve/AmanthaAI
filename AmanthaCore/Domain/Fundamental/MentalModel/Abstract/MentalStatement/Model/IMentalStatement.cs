using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model
{
    /// <summary>
    /// Base interface of Mental statement entities. Every each mental statement explains it's own emotional status.
    /// <param></param>
    /// <see cref="IMentalStatement"/> contains a properties which represented via <see cref="IMentalStatementProperty"/> interface.
    /// Mental statement allows external entities to apply any kind of different properties, derived from <see cref="IMentalStatementProperty"/>.
    /// </summary>
    internal interface IMentalStatement
    {
        /// <summary>
        /// The properties itself. Should be availabe for reading only.
        /// </summary>
        internal IEnumerable<IMentalStatementProperty> Properties { get; }

        /// <summary>
        /// Applying <see cref="IMentalStatementProperty"/> property to current <see cref="Properties"/> collection.
        /// </summary>
        /// <param name="property"></param>
        internal void ApplyProperty(IMentalStatementProperty property);

        /// <summary>
        /// Removes <see cref="IMentalStatementProperty"/> property from current <see cref="Properties"/> collection.
        /// <para></para>
        /// Throws an exception if <see cref="Properties"/> do not contains selected property.
        /// </summary>
        /// <param name="property"></param>
        internal void RemoveProperty(IMentalStatementProperty property);

        /// <summary>
        /// Represent statement type.
        /// </summary>
        internal MentalStatementType Type { get; }
    }
}
