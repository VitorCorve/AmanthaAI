namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract
{
    internal interface IMentalStatement
    {
        void Affect(IMentalStatementMediator mediator);
    }
}
