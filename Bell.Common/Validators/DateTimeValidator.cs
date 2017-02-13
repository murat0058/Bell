using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Bell.Common.Resources;
using FluentValidation;
using FluentValidation.Validators;

namespace Bell.Common.Validators
{
    public static class DateTimeValidatorExtension
    {
        public static IRuleBuilderOptions<T, TProperty> MustBeValidDateTime<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new EnumerationValidator<T>());
        }
    }

    public class DateTimeValidator<T> : PropertyValidator
    {
        public DateTimeValidator() : base(ErrorMessageKeys.VALIDATION_ERROR_ENUMERATION)
        {

        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var isValid = false;
            var dateTimeValue = context.PropertyValue;

            if (dateTimeValue != null)
            {
             
            }

            return isValid;
        }
    }
}
