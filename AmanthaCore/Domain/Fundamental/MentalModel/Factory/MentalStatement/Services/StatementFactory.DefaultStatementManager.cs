﻿using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;

using AmanthaLogger.Models;
using AmanthaLogger;

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
        }
    }
}