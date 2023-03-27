using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Concrete.MentalStatement.Model
{
    internal class MentalStatement : IMentalStatement
    {
        public IEnumerable<IMentalStatementProperty> Properties { get; set; }

        internal MentalStatement()
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
