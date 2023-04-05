using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;

namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model
{
    /// <summary>
    /// Mental statement manager which incapsulates mental statement module infrastructure, allows to initialize <see cref="StatementCells"/>, and also able to
    /// receive an entropy source.
    /// </summary>
    internal interface IMentalStatementManager
    {
        /// <summary>
        /// Statement cells. Should be availabe for reading only.
        /// </summary>
        internal IEnumerable<IMentalStatementCell> StatementCells { get; }

        /// <summary>
        /// Cells initialization.
        /// </summary>
        /// <param name="cells"></param>
        internal void InitializeCells(IEnumerable<IMentalStatementCell> cells);

        /// <summary>
        /// Receiving an entropy to pass it inside <see cref="StatementCells"/> collection.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        internal void ReceiveEntropySource<T>(T source);


        internal IEnumerable<IMentalStatementView> GetStatement();
    }
}
