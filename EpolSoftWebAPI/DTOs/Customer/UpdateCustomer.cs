using System;

namespace EpolSoft.WebAPI.DTOs.Customer
{
    public class UpdateCustomer
    {
        public int CustomerNumber { get; set; }
        public string Postcode { get; set; }
        public string Town { get; set; }
        public string PhoneNumber1 { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateChanged { get; set; }
    }
}
