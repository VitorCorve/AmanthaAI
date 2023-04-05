namespace AmanthaCore.Domain.Fundamental.MentalModel.Abstract.MentalStatementProperty.Model
{
    /// <summary>
    /// Property magnitude answers to question: how powerfull should be the property and how higher should be affectance.
    /// </summary>
    internal readonly struct PropertyMagnitude
    {
        /// <summary>
        /// Min value.
        /// </summary>
        internal const int Min = 0;

        /// <summary>
        /// Max value.
        /// </summary>
        internal const int Max = 10;

        /// <summary>
        /// Value.
        /// </summary>
        internal readonly int Value { get; }

        /// <summary>
        /// Sets value in range from <see cref="Min"/> to <see cref="Max"/>.
        /// </summary>
        /// <param name="value"></param>
        public PropertyMagnitude(int value)
        {
            Value = value < Min ? Min : value > Max ? Max : value;
        }

        public static implicit operator int(PropertyMagnitude value) => value.Value;

        public static implicit operator PropertyMagnitude(int value) => new(value);
    }
}
