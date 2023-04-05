namespace AmanthaDotnetExtensions
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Applies <see cref="Action{T}"/> on <see cref="IEnumerable{T}"/> <paramref name="enumerable"/>.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="enumerable"></param>
        /// <param name="action"></param>
        /// <returns></returns>
        public static IEnumerable<T> ForEach<T>(this IEnumerable<T> enumerable, Action<T> action)
        {
            foreach (var item in enumerable)
                action(item);

            return enumerable;
        }
    }
}
