using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        private class InsultedStatement : IMentalStatement
        {
            public IEnumerable<IMentalStatementProperty> Properties { get; set; } = new List<IMentalStatementProperty>();

            public MentalStatementType Type { get; } = MentalStatementType.Insulted;

            internal InsultedStatement()
            {
                Logger.Log();
            }

            public void ApplyProperty(IMentalStatementProperty property)
            {
                if (Properties is null)
                    throw new Exception("Properties is null");
                PerformanceStamp stamp = Logger.CreateStamp();

                if (Properties is List<IMentalStatementProperty> list)
                {
                    list.Add(property);
                }

                Logger.Log(stamp);
            }

            public void RemoveProperty(IMentalStatementProperty property)
            {
                if (Properties is null)
                    throw new Exception("Properties is null");

                PerformanceStamp stamp = Logger.CreateStamp();

                if (Properties is List<IMentalStatementProperty> list)
                {
                    if (list.Contains(property))
                        list.Remove(property);
                    else
                        throw new Exception("Properties do not contain selected property");
                }

                Logger.Log(stamp);
            }
        }
    }
}
