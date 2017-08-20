namespace MundiPagg.Benfeitor.BenfeitorApi.Models.Request
{

    public class CreateChargeRequest
    {

        public long AmountInCents { get; set; }

        public string Code { get; set; }

        public long PayerPersonId { get; set; }

        public string StatementDescriptor { get; set; }
    }
}