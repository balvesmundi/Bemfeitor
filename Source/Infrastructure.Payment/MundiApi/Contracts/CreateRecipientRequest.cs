namespace Infrastructure.Payment.MundiApi.Contracts
{

    public class CreateRecipientRequest
    {
        public string name { get; set; }
        public string email { get; set; }
        public string description { get; set; }
        public string document { get; set; }
        public string type { get; set; }
        public DefaultBankAccountRequest default_bank_account { get; set; }
    }
}
