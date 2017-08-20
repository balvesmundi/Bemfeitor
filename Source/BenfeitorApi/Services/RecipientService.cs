using Infrastructure.Payment.Contracts;
using Infrastructure.Payment.Seedwork;
using MundiPagg.Benfeitor.BenfeitorApi.Mappers;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Request;
using MundiPagg.Benfeitor.BenfeitorApi.Models.Response;

namespace MundiPagg.Benfeitor.BenfeitorApi.Services
{
    public class RecipientService : IRecipientService
    {

        private IPaymentFactory _paymentFactory;

        public RecipientService(IPaymentFactory paymentFactory)
        {
            this._paymentFactory = paymentFactory;
        }

        public RecipientResponse CreateRecipient(CreateRecipientRequest request)
        {

            var payment = this._paymentFactory.Create();

            var response = payment.CreateRecipient(RecipientMapper.MapCreateRecipientRequestDTO(request));

            return RecipientMapper.MapRecipientResponse(response);
        }

        #region IDisposable Members

        public void Dispose()
        {
        }

        #endregion
    }
}