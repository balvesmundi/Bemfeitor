using System.Configuration;

namespace Infrastructure.Payment.Seedwork
{

    public class PaymentFactory : IPaymentFactory
    {

        #region Public Methods

        public IPayment Create()
        {

            string paymentAffiliation = ConfigurationManager.AppSettings["MundiPaggSecretKey"];

            return new MundiApiPayment(paymentAffiliation);
        }
    }

    #endregion
}
