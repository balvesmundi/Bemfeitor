using BenfeitorApi.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
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

        public long? BalanceInCents { get; set; }
        public LoanTypeEnum LoanTypeEnum { get; set; }
        public long? LoanInCents { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TaxPerDay { get; set; }

        public AddressResponse Address { get; set; }

        public List<DocumentResponse> Documents { get; set; }
    }
}