using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.Aggregates.Enums;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Response
{
    public class LoanResponse
    {
        public long LoanHistoryId { get; set; }

        public string LoanStatusEnum { get; set; }


        public long AmountInCents { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? TaxPerDay { get; set; }

        public string LoanDescription { get; set; }


        public byte? LenderGrade { get; set; }

        public byte? BorrowerGrade { get; set; }

        public string CommentToLender { get; set; }

        public string CommentToBorrower { get; set; }

        public string BorrowerName { get; set; }

        public string LenderName { get; set; }
    }
}