using System;
using System.Collections.Generic;
using System.Linq;
using Bell.Common.Exceptions;

namespace Bell.Common.Extensions
{
    public static class EnumerableExtensions
    {
        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException();
            }

            if (!collection.Any())
            {
                throw new CollectionEmptyException();
            }
        }
    }
}
