using System;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Response
{

    public class RecipientBankAccountResponse
    {
        public string Id { get; set; }
        public string HolderName { get; set; }
        public string HolderType { get; set; }
        public string HolderDocument { get; set; }
        public string Bank { get; set; }
        public string BranchNumber { get; set; }
        public string BranchCheckDigit { get; set; }
        public string AccountNumber { get; set; }
        public string AccountCheckDigit { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
