using AmanthaCore.Domain.Fundamental.Abstractions.Types.MentalStatement;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Affectors;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Model;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatement.Services;
using AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model;

using AmanthaLogger;

namespace AmanthaCore.Domain.Fundamental.Abstractions.Factory
{
    /// <summary>
    /// Statements factory, which incapsulates Mental Statement-type entities creation.
    /// There are several overloads for <see cref="FactoryMethod(MentalStatementType)"/>, 
    /// which can be initialized via Mental Statements module entity types.
    /// </summary>
    internal sealed partial class StatementFactory
    {
        /// <summary>
        /// Creates <see cref="IMentalStatementMediator"/> depended to <see cref="MentalStatementMediatorType"/>.
        /// </summary>
        /// <param name="mediator"></param>
        /// <returns></returns>
        internal static IMentalStatementMediator FactoryMethod(MentalStatementMediatorType mediator)
        {
            Logger.Log();

            switch (mediator)
            {
                default:
                    return new DefaultMediator();
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatementBuilder"/> depended to <see cref="MentalStatementBuilderType"/> and <see cref="MentalStatementType"/>.
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        internal static IMentalStatementBuilder FactoryMethod(MentalStatementBuilderType builder, MentalStatementType type)
        {
            Logger.Log();

            switch (builder)
            {
                default:
                    return new DefaultStatementBuilder(type);
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatementCell"/> depended to <see cref="MentalStatementCellType"/>.
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        internal static IMentalStatementCell FactoryMethod(MentalStatementCellType cell)
        {
            Logger.Log();

            switch (cell)
            {
                default:
                    return new DefaultStatementCell();
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatementManager"/> depended to <see cref="MentalStatementManagerType"/>.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        internal static IMentalStatementManager FactoryMethod(MentalStatementManagerType manager)
        {
            Logger.Log();

            switch (manager)
            {
                default:
                    return new DefaultStatementManager();
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatementCell"/> array with <paramref name="arrayLength"/>, where each item depended to <see cref="MentalStatementCellType"/>.
        /// </summary>
        /// <param name="cell"></param>
        /// <param name="arrayLength"></param>
        /// <returns></returns>
        internal static IMentalStatementCell[] ArrayFactoryMethod(MentalStatementCellType cell, int arrayLength)
        {
            Logger.Log();

            switch (cell)
            {
                default:
                    IMentalStatementCell[] array = new IMentalStatementCell[arrayLength];

                    for (int i = 0; i < arrayLength; i++)
                    {
                        array[i] = new DefaultStatementCell();
                    }

                    return array;
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatementProperty"/> depended to <see cref="MentalStatementProperty"/>.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        internal static IMentalStatementProperty FactoryMethod(MentalStatementProperty property)
        {
            Logger.Log();

            switch (property)
            {
                default:
                    return new DefaultStatementProperty();
            }
        }

        /// <summary>
        /// Creates <see cref="IMentalStatement"/> depended to <see cref="MentalStatementType"/>.
        /// </summary>
        /// <param name="manager"></param>
        /// <returns></returns>
        private static IMentalStatement FactoryMethod(MentalStatementType statement)
        {
            Logger.Log();

            return statement switch
            {
                MentalStatementType.Happy => new HappyStatement(),
                MentalStatementType.Sad => new SadStatement(),
                MentalStatementType.Default => new DefaultStatement(),
                MentalStatementType.Interested => new InterestedStatement(),
                MentalStatementType.Excited => new ExcitedStatement(),
                MentalStatementType.Indifferent => new IndifferentStatement(),
                MentalStatementType.Feared => new FearedStatement(),
                MentalStatementType.Usual => new UsualStatement(),
                MentalStatementType.Relaxing => new RelaxingStatement(),
                _ => new DefaultStatement()
            };
        }
    }
}
