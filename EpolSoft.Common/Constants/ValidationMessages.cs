namespace EpolSoft.Common.Constants
{
    //Validation messages are constants in English. Other languages should be handled by client side
    public static class ValidationMessages
    {
        public const string LengthValidation = "Maximum length {0}";
        public const string NotEmpty = "Property cannot be empty";
        public const string UppercaseLetter = "Property must have at least one uppercase letter";
        public const string LowercaseLetter = "Property must have at least one lowercase letter";
        public const string Digit = "Property must have at least one digit";
        public const string NotValidEmail = "Email is not valid";

    }
}
