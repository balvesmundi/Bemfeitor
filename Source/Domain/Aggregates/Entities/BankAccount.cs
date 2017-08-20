using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundiPagg.BenfeitorDomain.Aggregates.Entities
{
    public class BankAccount
    {
        public long BankAccountId { get; set; }

        public long PersonId { get; set; }

        public string HolderName { get; set; }

        public string HolderType { get; set; }

        public string HolderDocument { get; set; }

        public string Bank { get; set; }

        public string BranchNumber { get; set; }

        public string BranchCheckDigit { get; set; }

        public string AccountNumber { get; set; }

        public string AccountCheckDigit { get; set; }

        public string Type { get; set; }
    }
}
