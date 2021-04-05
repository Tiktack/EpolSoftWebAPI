using System;

namespace EpolSoft.WebAPI.DTOs.Customer
{
    public class CreateCustomer
    {
        public string Password { get; set; }
        public string Surname { get; set; }
        public string FirstNames { get; set; }
        public string Address1 { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string PhoneNumber1 { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateChanged { get; set; }
        public string UpdatedBy { get; set; }
    }
}
