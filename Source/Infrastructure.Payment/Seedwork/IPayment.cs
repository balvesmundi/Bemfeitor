using Infrastructure.Payment.Contracts;

namespace Infrastructure.Payment.Seedwork
{
    public interface IPayment
    {
        CreateRecipientResponseDTO CreateRecipient(CreateRecipientRequestDTO requestDTO);
    }
}