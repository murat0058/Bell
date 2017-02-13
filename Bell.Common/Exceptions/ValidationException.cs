using System;
using System.Collections.Generic;
using Bell.Common.Resources;
using FluentValidation.Results;

namespace Bell.Common.Exceptions
{
    public class ValidationException : UserReportableException
    {
        #region Private Fields

        private static readonly IDictionary<string, List<string>> _errorMessageMappings = new Dictionary<string, List<string>>
        {
            { ErrorMessageKeys.VALIDATION_ERROR_EMAIL, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_EMPTY, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_ENUMERATION, new List<string> {"PropertyName", "ComparisonValue"} },
            { ErrorMessageKeys.VALIDATION_ERROR_EXACT_LENGTH, new List<string> {"PropertyName", "MaxLength"} },
            { ErrorMessageKeys.VALIDATION_ERROR_EXCLUSIVE_BETWEEEN, new List<string> {"PropertyName", "From", "To"} },
            { ErrorMessageKeys.VALIDATION_ERROR_GREATER_THAN, new List<string> {"PropertyName", "ComparisonValue"} },
            { ErrorMessageKeys.VALIDATION_ERROR_GREATER_THAN_OR_EQUAL, new List<string> {"PropertyName", "ComparisonValue"} },
            { ErrorMessageKeys.VALIDATION_ERROR_INCLUSIVE_BETWEEN, new List<string> {"PropertyName", "From", "To"} },
            { ErrorMessageKeys.VALIDATION_ERROR_LENGTH, new List<string> {"PropertyName", "MinLength", "MaxLength"} },
            { ErrorMessageKeys.VALIDATION_ERROR_LESS_THAN, new List<string> {"PropertyName", "ComparsionValue"} },
            { ErrorMessageKeys.VALIDATION_ERROR_LESS_THAN_OR_EQUAL, new List<string> {"PropertyName", "ComparsionValue" } },
            { ErrorMessageKeys.VALIDATION_ERROR_NOT_EMPTY, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_NOT_EQUAL, new List<string> {"PropertyName", "ComparisonValue"} },
            { ErrorMessageKeys.VALIDATION_ERROR_NOT_NULL, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_NULL, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_PREDICATE, new List<string> {"PropertyName"} },
            { ErrorMessageKeys.VALIDATION_ERROR_REGEX, new List<string> {"PropertyName"} }
        };

        #endregion

        #region Constructors

        public ValidationException(ValidationResult result) : base(ErrorMessageKeys.VALIDATION_ERRORS)
        {
            GenerateExceptionMessages(result);
        }

        public ValidationException(Exception exception, ValidationResult result)
            : base(exception, new UserReportableMessage(ErrorMessageKeys.VALIDATION_ERRORS))
        {
            GenerateExceptionMessages(result);
        }

        #endregion

        #region Private Methods

        private void GenerateExceptionMessages(ValidationResult result)
        {
            foreach (var failure in result.Errors)
            {
                var key = failure.ErrorMessage;
                var args = new List<object>();

                List<string> errorMessageMap;

                if (_errorMessageMappings.TryGetValue(key, out errorMessageMap))
                {
                    foreach (var errorMessageValue in errorMessageMap)
                    {
                        AddValue(args, failure, errorMessageValue);
                    }
                }

                ErrorMessages.Add(new UserReportableMessage(key, args));
            }
        }

        private void AddValue(List<object> args, ValidationFailure failure, string valueName)
        {
            object value;

            if (failure.FormattedMessagePlaceholderValues.TryGetValue(valueName, out value))
            {
                args.Add(value);
            }
        }

        #endregion
    }
}
