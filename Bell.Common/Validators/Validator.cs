using Bell.Common.Exceptions;
using Bell.Common.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace Bell.Common.Validators
{
    public class Validator<T> : AbstractValidator<T>
    {
        public override ValidationResult Validate(T model)
        {
            if (model == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_NULL_VALUE, typeof(T));
            }

            return base.Validate(model);
        }

        public void ValidateAndThrowErrors(T model)
        {
            var result = Validate(model);

            if (!result.IsValid)
            {
               throw new Exceptions.ValidationException(result); 
            }
        }
    }
}
