using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Common;

using AmanthaDotnetExtensions;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementManager"/> interface implementation for architecture building purpose.
        /// </summary>
        private class DefaultStatementManager : IMentalStatementManager
        {
            public IEnumerable<IMentalStatementCell> StatementCells { get; private set; }

            internal DefaultStatementManager()
            {
                StatementCells = new List<IMentalStatementCell>();
                Logger.Log();

                InitializeDefaultBehavior();
            }

            public void InitializeCells(IEnumerable<IMentalStatementCell> cells)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                if (StatementCells is List<IMentalStatementCell> list)
                {
                    list.AddRange(cells);
                }

                Logger.Log(stamp);

            }

            public void ReceiveEntropySource<T>(T source)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                foreach (IMentalStatementCell cell in StatementCells)
                {
                    cell.Entropy(source);
                }

                Logger.Log(stamp);
            }

            private void InitializeDefaultBehavior()
            {
                // We wants to create main behavior mediators to affects to depended statements.
                IMentalStatementMediator pleasureMediator = FactoryMethod(MentalStatementMediatorType.Pleasure);
                IMentalStatementMediator painMediator = FactoryMethod(MentalStatementMediatorType.Pain);

                IMentalStatementBuilder builder = FactoryMethod(MentalStatementBuilderType.StatementBuilder);

                IMentalStatement[] pleasureStatements = CreatePleasureStatements(builder);
                IMentalStatement[] painStatements = CreatePainStatements(builder);

                // Create cells
                IMentalStatementCell pleasureCell = FactoryMethod(MentalStatementCellType.Default);
                IMentalStatementCell painCell = FactoryMethod(MentalStatementCellType.Default);

                // Initialize statements for each cell
                pleasureStatements.ForEach(pleasureCell.InitializeStatement);
                painStatements.ForEach(painCell.InitializeStatement);

                // Set mediators for cells
                pleasureCell.InitializeMediator(pleasureMediator);
                painCell.InitializeMediator(painMediator);

                IMentalStatementCell[] cells = new IMentalStatementCell[2];

                cells[0] = pleasureCell;
                cells[1] = painCell;

                // Initialize cells
                StatementCells = cells;
            }

            private static IMentalStatement[] CreatePleasureStatements(IMentalStatementBuilder builder)
            {
                IMentalStatement[] statements = new IMentalStatement[5];

                statements[0] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Usual);
                statements[1] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Relaxing);
                statements[2] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Happy);
                statements[3] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Excited);
                statements[4] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Interested);

                return statements;
            }

            private static IMentalStatement[] CreatePainStatements(IMentalStatementBuilder builder)
            {
                IMentalStatement[] statements = new IMentalStatement[4];

                statements[0] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Indifferent);
                statements[1] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Feared);
                statements[2] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Sad);
                statements[3] = builder.ApplyProperty(FactoryMethod(MentalStatementProperty.Magnitude)).Build(MentalStatementType.Insulted);

                return statements;
            }

            public IEnumerable<IMentalStatementView> GetStatement()
            {
                IMentalStatementView[] views = (from statement in StatementCells.SelectMany(x => x.Statements)
                                                from property in statement.Properties
                                                select new MentalStatementView(statement.Type, property.Magnitude))
                                                .ToArray();

                return views;
            }
        }
    }
}
