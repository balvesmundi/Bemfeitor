namespace Infrastructure.Payment.Contracts
{

    public class CreateChargeRequestDTO
    {

        public long Amount { get; set; }

        public string Code { get; set; }

        public string RecipientId { get; set; }

        public string CustomerId { get; set; }

        public bool Capture { get; set; }

        public string CardId { get; set; }

        public string StatementDescriptor { get; set; }
    }
}
