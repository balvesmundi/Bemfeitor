﻿using System;

namespace Repository.Entities
{
    public class LoanHistory
    {
        public long LoanHistoryId { get; set; }

        public long PersonLenderId { get; set; }

        public long PersonBorrowerId { get; set; }

        public string LoanStatusEnum { get; set; }

        public long AmountInCents { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? TaxPerDay { get; set; }

        public byte? LenderGrade { get; set; }

        public byte? BorrowerGrade { get; set; }

        public string CommentToLender { get; set; }

        public string CommentToBorrower { get; set; }

        public DateTime CreateDate { get; set; }
    }

}
