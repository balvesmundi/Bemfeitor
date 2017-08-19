using System;

namespace Infrastructure.Payment.MundiApi.Contracts
{

    public class CreateRecipientResponse
    {

        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string document { get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public DefaultBankAccountResponse default_bank_account { get; set; }
        public GatewayRecipientsResponse[] gateway_recipients { get; set; }
    }
}
