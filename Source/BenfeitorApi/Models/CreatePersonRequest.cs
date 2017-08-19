using System;

namespace BenfeitorApi.Models
{

    public class CreatePersonRequest
    {

        public string Email { get; set; }
        public string Name { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string GenderEnum { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public DateTime BirthDate { get; set; }

        public CreateAddressRequest Address { get; set; }
    }
}