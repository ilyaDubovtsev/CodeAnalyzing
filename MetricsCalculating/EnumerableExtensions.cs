using System.Collections.Generic;
using System.Linq;

namespace MetricsCalculating
{
    public static class EnumerableExtensions
    {
        public static int GetMedian(this IEnumerable<int> collection)
        {
            var orderedCollection = collection.OrderBy(x => x).ToArray();
            var indexOfMedian = orderedCollection.Count() / 2;
            return orderedCollection[indexOfMedian];
        }
    }
}