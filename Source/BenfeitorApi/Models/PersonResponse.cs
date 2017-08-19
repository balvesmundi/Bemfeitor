using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenfeitorApi.Models
{
    public class PersonResponse
    {

        public Guid PersonKey { get; set; }
        public DateTime CreateDate { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string GenderEnum { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public DateTime? BirthDate { get; set; }

        public AddressResponse Address { get; set; }
    }
}