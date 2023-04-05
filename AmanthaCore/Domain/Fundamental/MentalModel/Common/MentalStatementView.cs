using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Common
{
    public class MentalStatementView : IMentalStatementView
    {
        public string Type { get; private set; } = string.Empty;

        public int Magnitude { get; private set; }

        internal MentalStatementView(MentalStatementType type, PropertyMagnitude magnitude)
        {
            Type = type.ToString();
            Magnitude = magnitude;
        }
    }
}
