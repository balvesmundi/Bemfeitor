using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
{
    public class CreateLoanRequest
    {
        public Guid PersonLenderKey { get; set; }
        public Guid PersonBorrowerKey { get; set; }
        public long AmountInCents { get; set; }
        public DateTime? DueDate { get; set; }
        public decimal? TaxPerDay { get; set; }

    }
}