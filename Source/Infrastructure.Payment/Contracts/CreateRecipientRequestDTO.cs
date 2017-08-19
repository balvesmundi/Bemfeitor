namespace Infrastructure.Payment.Contracts
{

    public class CreateRecipientRequestDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public string Type { get; set; }
        public DefaultBankAccountRequestDTO DefaultBankAccount { get; set; }
    }
}
