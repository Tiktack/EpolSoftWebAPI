using EpolSoft.Common.Constants;
using FluentValidation;

namespace EpolSoft.Common.Extensions
{
    public static class RuleBuilderExtensions
    {
        public static IRuleBuilder<T, string> Password<T>(this IRuleBuilder<T, string> ruleBuilder, int minimumLength = 14)
        {
            var options = ruleBuilder
                .NotEmpty().WithMessage(ValidationMessages.NotEmpty)
                .MinimumLength(minimumLength)
                .Matches("[A-Z]").WithMessage(ValidationMessages.UppercaseLetter)
                .Matches("[a-z]").WithMessage(ValidationMessages.LowercaseLetter)
                .Matches("[0-9]").WithMessage(ValidationMessages.Digit);
            return options;
        }
    }
}
