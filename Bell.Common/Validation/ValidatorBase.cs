using Bell.Common.Exceptions;
using Bell.Common.Resources;
using FluentValidation;
using FluentValidation.Results;

namespace Bell.Common.Validation
{
    public interface IValidatorBase<in T>
    {
        ValidationResult Validate(T model);

        void ValidateAndThrowErrors(T model);
    }

    public abstract class ValidatorBase<T> : AbstractValidator<T>, IValidatorBase<T>
    {
        public override ValidationResult Validate(T model)
        {
            if (model == null)
            {
                throw new UserReportableException(ErrorMessageKeys.ERROR_NULL_VALUE, typeof(T).Name);
            }

            return base.Validate(model);
        }

        public virtual void ValidateAndThrowErrors(T model)
        {
            var result = Validate(model);

            if (!result.IsValid)
            {
               throw new Exceptions.ValidationException(result); 
            }
        }
    }
}
