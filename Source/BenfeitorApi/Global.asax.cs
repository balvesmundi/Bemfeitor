using System.Web.Http;
using MundiPagg.Benfeitor.BenfeitorApi;
using MundiPagg.Benfeitor.BenfeitorApi.Services;
using MundiPagg.Benfeitor.Repository;
using MundiPagg.Benfeitor.Repository.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace BenfeitorApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            // Create the container as usual.
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            // Register your types, for instance using the scoped lifestyle:
            container.Register<IPersonRepository, PersonRepository>(Lifestyle.Scoped);
            container.Register<IPersonService, PersonService>(Lifestyle.Scoped);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}
