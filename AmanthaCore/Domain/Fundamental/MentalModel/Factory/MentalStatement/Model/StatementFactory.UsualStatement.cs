using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        private class UsualStatement : IMentalStatement
        {
            public IEnumerable<IMentalStatementProperty> Properties { get; set; }

            public MentalStatementType Type { get; private set; } = MentalStatementType.Usual;

            internal UsualStatement()
            {
                Properties = new List<IMentalStatementProperty>();
                Logger.Log();
            }

            public void ApplyProperty(IMentalStatementProperty property)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                if (Properties is List<IMentalStatementProperty> list)
                {
                    list.Add(property);
                }

                Logger.Log(stamp);
            }
        }
    }
}
