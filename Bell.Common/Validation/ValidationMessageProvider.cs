using Bell.Common.Resources;

namespace Bell.Common.Validation
{
    public static class ValidationMessageProvider
    {
        public static string email_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_EMAIL; }
        }

        public static string empty_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_EMPTY; }
        }

        public static string enum_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_ENUMERATION; }
        }

        public static string equal_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_EQUAL; }
        }

        public static string exact_length_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_EXACT_LENGTH; }
        }

        public static string exclusivebetween_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_EXCLUSIVE_BETWEEEN; }
        }

        public static string greaterthan_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_GREATER_THAN; }
        }

        public static string greaterthanorequal_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_GREATER_THAN_OR_EQUAL; }
        }

        public static string inclusivebetween_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_INCLUSIVE_BETWEEN; }
        }

        public static string length_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_LENGTH; }
        }

        public static string lessthan_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_LESS_THAN; }
        }

        public static string lessthanorequal_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_LESS_THAN_OR_EQUAL; }
        }

        public static string notempty_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_NOT_EMPTY; }
        }

        public static string notequal_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_NOT_EQUAL; }
        }

        public static string notnull_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_NOT_NULL; }
        }

        public static string null_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_NULL; }
        }

        public static string predicate_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_PREDICATE; }
        }

        public static string regex_error
        {
            get { return ErrorMessageKeys.VALIDATION_ERROR_REGEX; }
        }
    }
}
