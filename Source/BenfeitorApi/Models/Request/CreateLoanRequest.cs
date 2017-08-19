using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BenfeitorApi.Models.Request
{
    public class CreateLoanRequest
    {
        public long PersonLenderId { get; set; }
        public long PersonBorrowerId { get; set; }
        public long AmountInCents { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TaxPerDay { get; set; }

    }
}