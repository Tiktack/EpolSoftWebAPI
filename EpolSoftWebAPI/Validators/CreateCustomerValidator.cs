using EpolSoft.Common.Constants;
using EpolSoft.Common.Extensions;
using EpolSoft.WebAPI.DTOs.Customer;
using FluentValidation;

namespace EpolSoft.WebAPI.Validators
{
    /// <inheritdoc />
    public class CreateCustomerValidator : AbstractValidator<CreateCustomer>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.Password).MaximumLength(50).WithMessage(string.Format(ValidationMessages.LengthValidation, 50));
            RuleFor(x => x.Password).Password();

            RuleFor(x => x.Surname).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Surname).MaximumLength(50).WithMessage(string.Format(ValidationMessages.LengthValidation, 50));

            RuleFor(x => x.FirstNames).MaximumLength(50).WithMessage(string.Format(ValidationMessages.LengthValidation, 50));

            RuleFor(x => x.Address1).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Address1).MaximumLength(100).WithMessage(string.Format(ValidationMessages.LengthValidation, 100));

            RuleFor(x => x.Postcode).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Postcode).MaximumLength(10).WithMessage(string.Format(ValidationMessages.LengthValidation, 10));

            RuleFor(x => x.Town).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.Town).MaximumLength(50).WithMessage(string.Format(ValidationMessages.LengthValidation, 50));

            RuleFor(x => x.PhoneNumber1).MaximumLength(20).WithMessage(string.Format(ValidationMessages.LengthValidation, 20));

            RuleFor(x => x.EmailAddress).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.EmailAddress).MaximumLength(100).WithMessage(string.Format(ValidationMessages.LengthValidation, 100));
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage(ValidationMessages.NotValidEmail);

            RuleFor(x => x.DateChanged).NotEmpty().WithMessage(ValidationMessages.NotEmpty);

            RuleFor(x => x.UpdatedBy).NotEmpty().WithMessage(ValidationMessages.NotEmpty);
            RuleFor(x => x.UpdatedBy).MaximumLength(255).WithMessage(string.Format(ValidationMessages.LengthValidation, 255));
        }
    }
}
