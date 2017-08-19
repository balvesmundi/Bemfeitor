using BenfeitorApi.Models.Enums;
using BenfeitorApi.Models.Request;
using System;
using System.Collections.Generic;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
{

    public class CreatePersonRequest
    {

        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FacebookId { get; set; }
        public string TwitterId { get; set; }
        public string GenderEnum { get; set; }
        public string MobilePhone { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public DateTime BirthDate { get; set; }
        public long? BalanceInCents { get; set; }
        public LoanTypeEnum LoanTypeEnum { get; set; }
        public long? LoanInCents { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TaxPerDay { get; set; }

        public CreateAddressRequest Address { get; set; }

        public List<CreateDocumentRequest> Documents { get; set; }
    }
}