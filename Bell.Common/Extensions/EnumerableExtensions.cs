using System;
using System.Collections.Generic;
using System.Linq;
using Bell.Common.Exceptions;
using Bell.Common.Resources;

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

        public static void ThrowUserErrorIfNullOrEmpty<T>(this IEnumerable<T> collection)
        {
            var type = typeof(T);
            var typeName = $"IEnumerable<{type.Name}>";

            if (collection == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_NULL_VALUE, typeName);
            }

            if (!collection.Any())
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_EMPTY_COLLECTION, typeName);
            }
        }
    }
}
