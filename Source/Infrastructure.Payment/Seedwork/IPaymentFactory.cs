namespace Infrastructure.Payment.Seedwork
{

    public interface IPaymentFactory {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        IPayment Create();
    }
}
