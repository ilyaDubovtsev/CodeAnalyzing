using System.Collections.Generic;
using System.Linq;

namespace MetricsCalculating
{
    public static class EnumerableExtensions
    {
        public static int GetMedian(this IEnumerable<int> collection)
        {
            var orderedCollection = collection.OrderBy(x => x).ToArray();

            var count = orderedCollection.Count();
            if (count == 0)
            {
                return 0;
            }

            var indexOfMedian = count / 2;

            if (count % 2 == 0 && indexOfMedian != 0)
            {
                var indexOfPreMedian = indexOfMedian - 1;
                return (orderedCollection[indexOfPreMedian] + orderedCollection[indexOfMedian]) / 2;
            }

            return orderedCollection[indexOfMedian];
        }
    }
}