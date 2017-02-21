using Bell.Common.Exceptions;
using Bell.Common.Resources;

namespace Bell.Common.Extensions
{
    public static class StringExtensions
    {
        public static void ThrowUserErrorIfNullOrEmpty(this string value, string name)
        {
            if (value == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_STRING_NULL, name);
            }

            if (string.IsNullOrEmpty(value))
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_STRING_EMPTY, name);
            }
        }

        public static void ThrowUserErrorIfNullOrWhitespace(this string value, string name)
        {
            if (value == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_STRING_NULL, name);
            }

            if (string.IsNullOrWhiteSpace(value))
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_STRING_ONLY_WHITE_SPACE, name);
            }
        }
    }
}
