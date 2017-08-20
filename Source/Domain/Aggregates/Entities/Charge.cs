using System;

namespace Domain.Aggregates.Entities
{
    public class Charge
    {

        public long ChargeId { get; set; }

        public long AmountInCents { get; set; }

        public string Code { get; set; }

        public string GatewayId { get; set; }

        public string Status { get; set; }

        public DateTime CreateDate { get; set; }

        public long PayerPersonId { get; set; }

        public virtual Person Payer { get; set; }

        public virtual LoanHistory LoanHistory { get; set; }
    }
}