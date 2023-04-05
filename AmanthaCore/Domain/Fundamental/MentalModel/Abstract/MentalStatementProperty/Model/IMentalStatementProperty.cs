using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model
{
    /// <summary>
    /// Mental statement property. Should explore <see cref="IMentalStatement"/> behavior in details in future.
    /// </summary>
    internal interface IMentalStatementProperty
    {
        /// <summary>
        /// Property magnitude.
        /// </summary>
        internal PropertyMagnitude Magnitude { get; }

        /// <summary>
        /// Changes property magnitude.
        /// </summary>
        /// <param name="magnitude"></param>
        internal void ChangeMagnitude(int magnitude);

        /// <summary>
        /// Changes property magnitude.
        /// </summary>
        /// <param name="magnitude"></param>
        internal void ChangeMagnitude(PropertyMagnitude magnitude);
    }
}
