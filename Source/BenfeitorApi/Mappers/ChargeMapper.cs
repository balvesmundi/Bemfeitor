using Domain.Aggregates.Entities;
using Infrastructure.Payment.Contracts;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Mappers
{
    public class ChargeMapper
    {

        public static CreateChargeRequestDTO MapCreateChargeRequestDTO(CreateChargeRequest request, Person person)
        {

            return new CreateChargeRequestDTO()
            {
                Amount = request.AmountInCents,
                Capture = true,
                CardId = person.MundiPaggCardId,
                Code = request.Code,
                CustomerId = person.MundiPaggCustomerId,
                RecipientId = person.MundiPaggRecipientId,
                StatementDescriptor = request.StatementDescriptor
            };
        }

        public static ChargeResponse MapChargeResponse(CreateChargeResponseDTO responseDTO, long chargeId)
        {

            return new ChargeResponse()
            {
                ChargeId = chargeId,
                GatewayId = responseDTO.GatewayId,
                Status = responseDTO.Status
            };
        }
    }
}