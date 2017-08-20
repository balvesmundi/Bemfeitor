using System;

namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Response
{

    public class RecipientResponse
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public RecipientBankAccountResponse RecipientBankAccount { get; set; }
    }
}
