using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bell.Common.Exceptions;
using Bell.Common.Resources;

namespace Bell.Common.Extensions
{
    public static class IntegerExtensions
    {
        public static void ThrowIfInvalidId(this int value)
        {
            if (value <= 0)
            {
                throw new InvalidIdException();
            }
        }

        public static void ThrowIfInvalidId(this long value)
        {
            if (value <= 0)
            {
                throw new InvalidIdException();
            }
        }

        public static void ThrowUserErrorIfInvalidId(this int value, string name)
        {
            if (value <= 0)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_VALUE_MUST_BE_POSITIVE, name);
            }
        }

        public static void ThrowUserErrorIfInvalidId(this long value, string name)
        {
            if (value <= 0)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_VALUE_MUST_BE_POSITIVE, name);
            }
        }
    }
}
