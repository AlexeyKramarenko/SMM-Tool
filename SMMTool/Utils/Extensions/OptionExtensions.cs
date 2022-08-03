using SMMTool.Utils.Optional;

namespace SMMTool.Utils.Extensions
{
    internal static class OptionExtensions
    {
        public static Option<T> FirstOrNone<T>(this IEnumerable<T> sequence) =>
            sequence.Select(x => (Option<T>)new Some<T>(x))
                .DefaultIfEmpty(new None<T>())
                .First();

        public static Option<T> FirstOrNone<T>(
            this IEnumerable<T> sequence, Func<T, bool> predicate) =>
            sequence.Where(predicate).FirstOrNone();

        public static IEnumerable<TResult> SelectOptional<T, TResult>(
            this IEnumerable<T> sequence, Func<T, Option<TResult>> map) =>
            sequence.Select(map)
                .OfType<Some<TResult>>()
                .Select(some => some.Content);

        public static Option<TValue> TryGetValue<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key) =>
            dictionary.TryGetValue(key, out TValue value) ? new Some<TValue>(value)
            : (Option<TValue>)new None<TValue>(); 
        
        public static Option<T> When<T>(this T obj, bool condition) =>

            condition ? new Some<T>(obj)
            : (Option<T>)new None<T>();

        public static Option<T> When<T>(this T obj, Func<T, bool> predicate) =>
            obj.When(predicate(obj));

        public static Option<T> NoneIfNull<T>(this T obj) =>
            obj.When(!object.ReferenceEquals(obj, null));
    }
}
