using System;

namespace Infrastructure.Payment.Contracts
{

    public class CreateRecipientResponseDTO
    {

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime Created_at { get; set; }
        public DateTime Updated_at { get; set; }
        public DefaultBankAccountResponseDTO DefaultBankAccount { get; set; }
    }
}
