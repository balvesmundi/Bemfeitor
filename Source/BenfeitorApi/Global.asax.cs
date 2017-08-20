using System.Net;
using System.Web.Http;
using Microsoft.Practices.Unity;
using MundiPagg.Benfeitor.BenfeitorApi;
using MundiPagg.Benfeitor.Infrastructure.Data;

namespace BenfeitorApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IUnityContainer _container;

        protected void Application_Start()
        {

            ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };

            GlobalConfiguration.Configure(WebApiConfig.Register);

            UnitOfWork.Initialize();
        }
    }
}
