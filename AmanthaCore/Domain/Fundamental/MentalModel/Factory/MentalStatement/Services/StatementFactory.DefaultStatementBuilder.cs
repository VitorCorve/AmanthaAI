using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementBuilder"/> interface implementation for architecture building purpose.
        /// </summary>
        private class DefaultStatementBuilder : IMentalStatementBuilder
        {
            private IMentalStatement _statement;
            private readonly MentalStatementType _statementType;

            internal DefaultStatementBuilder(MentalStatementType type)
            {
                _statementType = type;
                _statement = FactoryMethod(_statementType);

                Logger.Log();
            }

            public IMentalStatementBuilder ApplyProperty(IMentalStatementProperty property)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                _statement.ApplyProperty(property);

                Logger.Log(stamp);

                return this;
            }

            public IMentalStatement Build()
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                IMentalStatement result = _statement;

                _statement = FactoryMethod(_statementType);

                Logger.Log(stamp);

                return result;
            }
        }
    }
}
