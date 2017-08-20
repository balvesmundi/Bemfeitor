using MundiPagg.BenfeitorDomain.Aggregates.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Aggregates.Entities
{
    public class Person
    {
        public long PersonId { get; set; }

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

        public string LoanTypeEnum { get; set; }

        public long? LoanInCents { get; set; }

        public DateTime? DueDate { get; set; }

        public decimal? TaxPerDay { get; set; }

        public bool IsEnabled { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public string BearerToken { get; set; }

        public virtual List<Address> Addresses { get; set; }

        public virtual List<Document> Documents { get; set; }

        public virtual List<BankAccount> BankAccount { get; set; }

        public long SumGrade { get; set; }

        public long CountGrade { get; set; }

        public int CountAsBorrower { get; set; }

        public int CountAsLender { get; set; }

        public string LoanReason { get; set; }

        public string MundiPaggRecipientId { get; set; }

        public string MundiPaggCustomerId { get; set; }

        public string MundiPaggCardId { get; set; }

        public virtual List<LoanHistory> BorrowedLoans { get; set; }

        public virtual List<LoanHistory> LendedLoans { get; set; }

        public virtual List<Charge> Charges { get; set; }
    }
}
