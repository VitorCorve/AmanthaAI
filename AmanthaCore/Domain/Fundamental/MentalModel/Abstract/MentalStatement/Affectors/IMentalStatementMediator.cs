using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors
{
    internal interface IMentalStatementMediator
    {
        void Affect(IMentalStatement statement);
    }
}
