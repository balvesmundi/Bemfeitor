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

        public List<Address> Addresses { get; set; }

        public List<Document> Documents { get; set; }
    }
}
