namespace Infrastructure.Payment.Contracts
{

    public class CreateChargeResponseDTO
    {

        public string Status { get; set; }

        public string GatewayId { get; set; }
    }
}
