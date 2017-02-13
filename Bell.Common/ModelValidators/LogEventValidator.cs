using Bell.Common.Models;
using Bell.Common.Validators;
using FluentValidation;

namespace Bell.Common.ModelValidators
{

    public class LogEventValidator : Validator<LogEvent>
    {
        public LogEventValidator(bool skipIdCheck = false)
        {
            //ValidatorOptions.ResourceProviderType = "";

            if (!skipIdCheck)
            {
                RuleFor(le => le.Id).GreaterThan(0);
            }

            RuleFor(le => le.ApplicationName).NotEmpty();
            RuleFor(le => le.MachineName).NotEmpty();
            RuleFor(le => le.ProcessId).GreaterThan(0);
            //RuleFor(le => le.UserId).Must(BeGreaterThanZeroIfHasValue).WithMessage()

            RuleFor(le => le.Level).IsInEnum();
            //RuleFor(le => le.Level).MustBeValidEnumeration();
            // Check that timestamp is valid
            //RuleFor(le => le.Timestamp).

        }

        private bool BeGreaterThanZeroIfHasValue(int? i)
        { 
            return !i.HasValue || i.Value > 0;
        }

    }
}
