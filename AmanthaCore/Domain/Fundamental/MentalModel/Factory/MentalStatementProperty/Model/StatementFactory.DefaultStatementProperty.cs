using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementProperty"/> interface implementation for architecture building purpose.
        /// </summary>
        private class DefaultStatementProperty : IMentalStatementProperty
        {
            internal DefaultStatementProperty()
            {
                Logger.Log();
            }
        }
    }
}
