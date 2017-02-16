using System;
using Bell.Common.Resources;
using FluentValidation;
using FluentValidation.Validators;

namespace Bell.Common.Validation
{
    public static class DateTimeValidatorExtension
    {
        public static IRuleBuilderOptions<T, TProperty> IsValidDateTime<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new DateTimeValidator<T>());
        }
    }

    public class DateTimeValidator<T> : PropertyValidator
    {
        private readonly DateTime _earliestDateAllowed;

        public DateTimeValidator() : base(ErrorMessageKeys.VALIDATION_ERROR_ENUMERATION)
        {
            _earliestDateAllowed = new DateTime(1753, 1, 1);
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var isValid = false;
            var dateTimeValue = context.PropertyValue;

            if (dateTimeValue != null)
            {
                var dateTime = (DateTime) dateTimeValue;

                if (dateTime > _earliestDateAllowed)
                {
                    isValid = true;
                }
            }

            return isValid;
        }
    }
}
