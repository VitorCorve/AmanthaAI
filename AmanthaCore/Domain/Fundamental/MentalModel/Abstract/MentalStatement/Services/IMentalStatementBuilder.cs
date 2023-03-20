using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services
{
    internal interface IMentalStatementBuilder<TStatement> where TStatement : IMentalStatement, new()
    {
        IMentalStatementBuilder<TStatement> ApplyProperty<TProperty>(TProperty statement) where TProperty : IMentalStatementProperty, new();

        TStatement Build();
    }
}
