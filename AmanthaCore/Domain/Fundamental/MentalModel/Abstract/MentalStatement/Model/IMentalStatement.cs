using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model
{
    internal interface IMentalStatement
    {
        IEnumerable<IMentalStatementProperty> Properties { get; }
    }
}
