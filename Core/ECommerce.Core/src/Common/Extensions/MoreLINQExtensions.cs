

namespace ECommerce.Core.Common.Extensions
{
    public static class MoreLINQExtensions
    {
        public static IEnumerable<TSource> DistinctByA<TSource, TKey>
            (this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            HashSet<TKey> seenKeys = new HashSet<TKey>();
            foreach (TSource element in source)
            {
                if (seenKeys.Add(keySelector(element)))
                {
                    yield return element;
                }
            }
        }
    }
}
