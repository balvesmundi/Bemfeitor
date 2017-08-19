using System.Web.Http;
using Microsoft.Practices.Unity;
using MundiPagg.Benfeitor.BenfeitorApi;
using MundiPagg.Benfeitor.BenfeitorApi.Services;
using MundiPagg.Benfeitor.Domain.Aggregates.Repositories;
using MundiPagg.Benfeitor.Infrastructure.Data;
using MundiPagg.Benfeitor.Infrastructure.Data.Repositories;

namespace BenfeitorApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        static IUnityContainer _container;

        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            UnitOfWork.Initialize();
        }
    }
}
