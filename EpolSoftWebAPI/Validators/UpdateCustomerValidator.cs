using EpolSoft.Common.Constants;
using EpolSoft.WebAPI.DTOs.Customer;
using FluentValidation;

namespace EpolSoft.WebAPI.Validators
{
    public class UpdateCustomerValidator : AbstractValidator<UpdateCustomer>
    {
        public UpdateCustomerValidator()
        {
            RuleFor(x => x.CustomerNumber).NotEmpty().WithMessage(ValidationMessages.NotEmpty);

            RuleFor(x => x.Postcode).MaximumLength(10).WithMessage(string.Format(ValidationMessages.LengthValidation, 10));

            RuleFor(x => x.Town).MaximumLength(50).WithMessage(string.Format(ValidationMessages.LengthValidation, 50));

            RuleFor(x => x.PhoneNumber1).MaximumLength(20).WithMessage(string.Format(ValidationMessages.LengthValidation, 20));

            RuleFor(x => x.EmailAddress).MaximumLength(100).WithMessage(string.Format(ValidationMessages.LengthValidation, 100));
            RuleFor(x => x.EmailAddress).EmailAddress().WithMessage(ValidationMessages.NotValidEmail);
        }
    }
}
