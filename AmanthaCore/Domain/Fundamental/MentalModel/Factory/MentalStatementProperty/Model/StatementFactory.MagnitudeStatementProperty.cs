using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementProperty"/> interface implementation for architecture building purpose.
        /// </summary>
        private class MagnitudeStatementProperty : IMentalStatementProperty
        {
            public PropertyMagnitude Magnitude { get; private set; }

            internal MagnitudeStatementProperty()
            {
                Logger.Log();
            }

            public void ChangeMagnitude(int magnitude) => Magnitude = magnitude;

            public void ChangeMagnitude(PropertyMagnitude magnitude) => Magnitude = magnitude;
        }
    }
}
