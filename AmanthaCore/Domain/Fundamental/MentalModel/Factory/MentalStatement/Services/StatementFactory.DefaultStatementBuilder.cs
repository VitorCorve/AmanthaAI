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
            private readonly List<IMentalStatementProperty> _properties;

            internal DefaultStatementBuilder()
            {
                _properties = new List<IMentalStatementProperty>();

                Logger.Log();
            }

            public IMentalStatementBuilder ApplyProperty(IMentalStatementProperty property)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                _properties.Add(property);

                Logger.Log(stamp);

                return this;
            }

            public IMentalStatement Build(MentalStatementType type)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                IMentalStatement result = FactoryMethod(type);

                foreach (IMentalStatementProperty property in _properties)
                    result.ApplyProperty(property);
                
                _properties.Clear();

                Logger.Log(stamp);

                return result;
            }
        }
    }
}
