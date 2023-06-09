﻿using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;

using AmanthaLogger;
using AmanthaLogger.Models;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Default <see cref="IMentalStatementMediator"/> interface implementation for architecture building purpose.
        /// </summary>
        private class DefaultMediator : IMentalStatementMediator
        {
            public MentalStatementMediatorType Type { get; } = MentalStatementMediatorType.Default;

            public void Affect(IMentalStatement statement)
            {
                PerformanceStamp stamp = Logger.CreateStamp();

                Logger.Log(stamp);
            }
        }
    }
}
