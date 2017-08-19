using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Response
{
    public class AddressResponse
    {

        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string Number { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
    }
}