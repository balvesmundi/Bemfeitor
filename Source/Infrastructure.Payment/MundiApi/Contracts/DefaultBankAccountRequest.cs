namespace Infrastructure.Payment.MundiApi.Contracts
{

    public class DefaultBankAccountRequest
    {
        public string holder_name { get; set; }
        public string holder_type { get; set; }
        public string holder_document { get; set; }
        public string bank { get; set; }
        public string branch_number { get; set; }
        public string branch_check_digit { get; set; }
        public string account_number { get; set; }
        public string account_check_digit { get; set; }
        public string type { get; set; }
    }
}
