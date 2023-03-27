using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Services
{
    internal class MentalStatementBuilder<TMentalStatement> : IMentalStatementBuilder<IMentalStatement> where TMentalStatement : IMentalStatement
    {
        private TMentalStatement _statement;

        internal MentalStatementBuilder()
        {
            _statement = (TMentalStatement)Activator.CreateInstance(typeof(TMentalStatement), nonPublic: true) ?? throw new Exception("Cannot create an instance");
            Logger.Log();
        }

        public IMentalStatementBuilder<IMentalStatement> ApplyProperty(IMentalStatementProperty property)
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

            _statement = (TMentalStatement)Activator.CreateInstance(typeof(TMentalStatement), nonPublic: true) ?? throw new Exception("Cannot create an instance");

            Logger.Log(stamp);

            return result;
        }
    }
}
