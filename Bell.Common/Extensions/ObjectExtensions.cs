using Bell.Common.Exceptions;
using Bell.Common.Resources;
using System;

namespace Bell.Common.Extensions
{
    public static class ObjectExtensions
    {
        public static void ThrowIfNull(this object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException();
            }
        }

        public static void ThrowUserErrorIfNull(this object obj, Type type)
        {
            if (obj == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_NULL_VALUE, type.Name);
            }
        }
    }
}
