namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
{

    public class CreateRecipientRequest
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }
        public string Document { get; set; }
        public string Type { get; set; }
        public CreateRecipientBankAccountRequest RecipientBankAccount { get; set; }
    }
}
