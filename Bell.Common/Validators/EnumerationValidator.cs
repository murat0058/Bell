using System;
using System.Reflection;
using Bell.Common.Resources;
using FluentValidation;
using FluentValidation.Validators;

namespace Bell.Common.Validators
{
    public static class EnumerationValidatorExtension
    {
        public static IRuleBuilderOptions<T, TProperty> MustBeValidEnumeration<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder)
        {
            return ruleBuilder.SetValidator(new EnumerationValidator<T>());
        }
    }

    public class EnumerationValidator<T> : PropertyValidator
    {
        public EnumerationValidator() : base(ErrorMessageKeys.VALIDATION_ERROR_ENUMERATION)
        {
            
        }

        protected override bool IsValid(PropertyValidatorContext context)
        {
            var isValid = false;
            var enumValue = context.PropertyValue;

            if (enumValue != null)
            {
                Type type = enumValue.GetType();

                if (type.GetTypeInfo().IsEnum)
                {
                    isValid = Enum.IsDefined(type, enumValue);
                }
            }

            return isValid;
        }
    }
}
